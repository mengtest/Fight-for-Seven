using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class LoginHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return TypeProtocol.TYPE_LOGIN;
        }
    }

    public override void Dispatch(int command, List<String> message)
    {
        switch (command)
        {
            case CommandProtocol.Login_InvalidMessage:
                MessageManager.instance.ShowLog("请重新登录...");
                break;
            case CommandProtocol.Login_InvalidAccount:
                MessageManager.instance.ShowLog("账号不存在...");
                break;
            case CommandProtocol.Login_InvalidPassword:
                MessageManager.instance.ShowLog("密码错误...");
                break;
            case CommandProtocol.Login_Failed:
                MessageManager.instance.ShowLog("登录失败...");
                break;
            case CommandProtocol.Login_Succeed:
                //登录成功，如果存在角色则加载，不存在则创建
                SocketModel getRoleRequset = new SocketModel();
                getRoleRequset.SetType(TypeProtocol.TYPE_GET_ROLE);
                getRoleRequset.SetArea(AreaProtocol.Area_GetRoleRequest);
                getRoleRequset.SetCommand(0);
                List<string> msg = new List<string>();
                msg.Add("");
                getRoleRequset.SetMessage(msg);
                MainClient.Instance.SendMsg(getRoleRequset);
                break;
        }
    }
}
