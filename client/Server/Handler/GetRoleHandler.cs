using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class GetRoleHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return TypeProtocol.TYPE_GET_ROLE;
        }
    }

    public override void Dispatch(int command, List<string> message)
    {
        switch (command)
        {
            case CommandProtocol.GetRole_InvalidMessage:
                MessageManager.instance.ShowLog("出错啦...");
                break;
            case CommandProtocol.GetRole_RoleNonExist:
                //不存在角色，加载到创建角色场景
                SceneManager.LoadScene(1);
                break;
            case CommandProtocol.GetRole_RoleExist:
                break;
            case CommandProtocol.GetRole_Failed:
                break;
            case CommandProtocol.GetRole_Succeed:
                //存在角色，加载到主场景
                SceneManager.LoadScene(2);
                break;
        }
    }
}
