using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateRoleHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return TypeProtocol.TYPE_CREATE_ROLE;
        }
    }

    public override void Dispatch(int command, List<string> message)
    {
        switch (command)
        {
            case CommandProtocol.CreateRole_InvalidMessage:
                MessageManager.instance.ShowLog("请重新按确认键...");
                break;
            case CommandProtocol.CreateRole_UsernameNonExist:
                break;
            case CommandProtocol.CreateRole_UsernameExist:
                MessageManager.instance.ShowLog("用户名已存在...");
                break;
            case CommandProtocol.CreateRole_Failed:
                MessageManager.instance.ShowLog("创建失败...");
                break;
            case CommandProtocol.CreateRole_Succeed:
                //创建成功，跳转到主场景
                SceneManager.LoadScene(2);
                break;
        }
    }
}
