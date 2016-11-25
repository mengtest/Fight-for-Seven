using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System;
using System.IO;
using ProtoBuf;
using System.Collections.Generic;

public class MainClient : MonoBehaviour
{
    private const string HOST = "127.0.0.1";
    private const int PORT = 9981;
    private static MainClient instance;
    public static Socket socket;

    private byte[] receiveBuf = new byte[1024];
    private bool isRead = false;

    private List<byte> cache = new List<byte>();
    public Queue<SocketModel> messages = new Queue<SocketModel>();
    public Dictionary<int, BaseHandler> handlers = new Dictionary<int, BaseHandler>();

    public static MainClient Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(HOST, PORT);
            socket.BeginReceive(receiveBuf, 0, 1024, SocketFlags.None, ReceiveMsg, receiveBuf);
            Debug.Log("connect succeed");
        }
        catch (Exception e)
        {
            Debug.Log("connect failed : " + e.Message);
            socket.Close();
        }
    }

    void OnApplicationQuit()
    {
        socket.Close();
    }

    public void SendMsg(SocketModel socketModel)
    {
        byte[] data = Serial(socketModel);
        //消息体结构：消息体长度+消息体
        byte[] msg = new byte[4 + data.Length];
        IntToBytes(data.Length).CopyTo(msg, 0);
        data.CopyTo(msg, 4);
        try
        {
            Debug.Log("sendMsg length : " + msg.Length + " -> " + BitConverter.ToString(msg));
            socket.Send(msg);
        }
        catch (Exception e)
        {
            Debug.Log("sendMsg failed : " + e.Message);
            socket.Close();
        }
    }

    private void ReceiveMsg(IAsyncResult ar)
    {
        try
        {
            //结束异步消息读取并获取消息长度
            int bytesCount = socket.EndReceive(ar);
            byte[] bytes = new byte[bytesCount];
            //将接收缓冲池的内容复制到临时消息存储数组
            Buffer.BlockCopy(receiveBuf, 0, bytes, 0, bytesCount);
            Debug.Log("ReceiveMsg length : " + bytesCount + " -> " + BitConverter.ToString(bytes));
            cache.AddRange(bytes);
            if (!isRead)
            {
                isRead = true;
                OnData();
            }
        }
        catch (Exception e)
        {
            Debug.Log("receiveMsg failed : " + e.Message);
            socket.Close();
        }
        socket.BeginReceive(receiveBuf, 0, 1024, SocketFlags.None, ReceiveMsg, receiveBuf);

        /** 以下代码不能正确处理粘包拆包 **/
        //int length = socket.EndReceive(ar);
        //Debug.Log("length : " + length);
        ////读取消息体的长度
        //if (isHead)
        //{
        //    byte[] lenByte = new byte[4];
        //    System.Array.Copy(receiveBuf, lenByte, 4);
        //    len = BytesToInt(lenByte, 0);
        //    isHead = false;          
        //    Debug.Log("len : " + len);
        //}
        ////读取消息体内容
        //if (!isHead)
        //{
        //    byte[] msgByte = new byte[len];
        //    System.Array.ConstrainedCopy(receiveBuf, 4, msgByte, 0, len);
        //    isHead = true;
        //    len = 0;
        //    message = DeSerial(msgByte);
        //    Debug.Log("decode : " + msgByte + " -> " + BitConverter.ToString(msgByte));
        //}
        //socket.BeginReceive(receiveBuf, 0, 1024, SocketFlags.None, ReceiveMsg, receiveBuf);
    }

    private void OnData()
    {
        //长度不足的时候说明消息未接收完成
        if (cache.Count < 4)
        {
            isRead = false;
            return;
        }

        //长度解码
        byte[] result = LengthDecode(ref cache);
        if (result == null)
        {
            isRead = false;
            return;
        }

        //将消息存储到消息列表
        SocketModel model = DeSerial(result);
        messages.Enqueue(model);

        //递归调用
        OnData();
    }

    public byte[] LengthDecode(ref List<byte> cache)
    {
        MemoryStream ms = new MemoryStream(cache.ToArray());
        BinaryReader br = new BinaryReader(ms);

        //读取消息头      
        int length = BytesToInt(cache.ToArray(), 0);
        //使流向后移动四位
        br.ReadInt32();

        if (length > ms.Length - ms.Position)
        {
            return null;
        }

        //读取消息体
        byte[] result = br.ReadBytes(length);
        //清空缓存并写入剩余缓存
        cache.Clear();
        cache.AddRange(br.ReadBytes((int)(ms.Length - ms.Position)));

        br.Close();
        ms.Close();
        return result;
    }

    private byte[] Serial(SocketModel socketModel)  //将SocketModel转化成字节数组
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Serializer.Serialize<SocketModel>(ms, socketModel);
            byte[] data = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(data, 0, data.Length);
            return data;
        }
    }

    public SocketModel DeSerial(byte[] msg)  //将字节数组转化成SocketModel
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(msg, 0, msg.Length);
            ms.Position = 0;
            SocketModel socketModel = Serializer.Deserialize<SocketModel>(ms);
            return socketModel;
        }
    }

    public static int BytesToInt(byte[] data, int offset)
    {
        int num = 0;
        for (int i = offset; i < offset + 4; ++i)
        {
            num <<= 8;
            num |= (data[i] & 0xff);
        }
        return num;
    }

    public static byte[] IntToBytes(int num)
    {
        byte[] bytes = new byte[4];
        for (int i = 0; i < 4; ++i)
        {
            bytes[i] = (byte)(num >> (24 - i * 8));
        }
        return bytes;
    }

    public void RegisterHandler(int type, BaseHandler handler)
    {
        handlers.Add(type, handler);
    }

    public void UnRegisterHandler(int type)
    {
        handlers.Remove(type);
    }
}
