using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GetRoleInfoHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return TypeProtocol.TYPE_GET_ROLE_INFO;
        }
    }

    public override void Dispatch(int command, List<string> message)
    {
        switch (command)
        {
            case CommandProtocol.GetRoleInfo_InvalidMessage:
                MessageManager.instance.ShowLog("出错啦...");
                break;
            case CommandProtocol.GetRoleInfo_Failed:
                MessageManager.instance.ShowLog("获取角色信息失败...");
                break;
            case CommandProtocol.GetRoleInfo_Succeed:
                //加载角色信息
                int index = Convert.ToInt32(message[0]);
                string username = message[1];
                GameManager.Instance.SetRole(index, username);
                break;
        }
    }
}
