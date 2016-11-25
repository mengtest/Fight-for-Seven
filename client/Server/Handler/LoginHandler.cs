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
            return Protocol.TYPE_LOGIN;
        }
    }

    public override void Dispatch(int command, List<String> message)
    {
        switch (command)
        {
            case LoginProtocol.Login_InvalidMessage:
                MessageManager.instance.ShowLog("请重新登录...");
                break;
            case LoginProtocol.Login_InvalidAccount:
                MessageManager.instance.ShowLog("账号不存在...");
                break;
            case LoginProtocol.Login_InvalidPassword:
                MessageManager.instance.ShowLog("密码错误...");
                break;
            case LoginProtocol.Login_Failed:
                MessageManager.instance.ShowLog("登录失败...");
                break;
            case LoginProtocol.Login_Succeed:
                //MessageManager.instance.ShowLog("登录成功...");
                SceneManager.LoadScene(1);
                break;
        }
    }
}
