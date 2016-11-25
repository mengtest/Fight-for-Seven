using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientHandler : MonoBehaviour
{
    private static int num = 0;

    void Update()
    {
        //处理事务
        while(MainClient.Instance.messages.Count > 0)
        {
            SocketModel model = MainClient.Instance.messages.Dequeue();
            BaseHandler handler;
            MainClient.Instance.handlers.TryGetValue(model.GetType(), out handler);
            handler.Dispatch(model.GetCommand(), model.GetMessage());

            int type = model.GetType();
            int area = model.GetArea();
            int command = model.GetCommand();
            List<string> msg = model.GetMessage();
            Debug.Log("num : " + ++num + " -> " + type + " " + area + " " + command + " " + msg[0] + " " + msg[1]);
        }
    }
}
