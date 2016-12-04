using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UpdateRoleHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return TypeProtocol.TYPE_UPDATE_ROLE;
        }
    }

    public override void Dispatch(int command, List<string> message)
    {
        switch (command)
        {
            case CommandProtocol.UpdateRole_InvalidMessage:
                MessageManager.instance.ShowLog("请重新按确认键...");
                break;
            case CommandProtocol.UpdateRole_Failed:
                MessageManager.instance.ShowLog("更新失败...");
                break;
            case CommandProtocol.UpdateRole_Succeed:
                MessageManager.instance.ShowLog("更新成功...");
                break;
        }
    }
}
