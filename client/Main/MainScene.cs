using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainScene : MonoBehaviour
{
    void Awake()
    {
        SocketModel getRoleInfoRequset = new SocketModel();
        getRoleInfoRequset.SetType(TypeProtocol.TYPE_GET_ROLE_INFO);
        getRoleInfoRequset.SetArea(AreaProtocol.Area_GetRoleInfoRequest);
        getRoleInfoRequset.SetCommand(0);
        List<string> message = new List<string>();
        message.Add("");
        getRoleInfoRequset.SetMessage(message);
        MainClient.Instance.SendMsg(getRoleInfoRequset);
    }

    public void SendChangeName(string changeName)  //发送更名信息到服务端
    {
        SocketModel changeNameRequset = new SocketModel();
        changeNameRequset.SetType(TypeProtocol.TYPE_UPDATE_ROLE);
        changeNameRequset.SetArea(AreaProtocol.Area_UpdateRoleRequest);
        changeNameRequset.SetCommand(0);
        List<string> message = new List<string>();
        message.Add(changeName);
        changeNameRequset.SetMessage(message);
        MainClient.Instance.SendMsg(changeNameRequset);
    }
}
