using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ResetHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return TypeProtocol.TYPE_RESET;
        }
    }

    public override void Dispatch(int command, List<String> message)
    {
        switch (command)
        {
            case CommandProtocol.Reset_InvalidMessage:
                MessageManager.instance.ShowLog("请重新修改密码...");
                break;
            case CommandProtocol.Reset_InvalidAccount:
                MessageManager.instance.ShowLog("账号不存在...");
                break;
            case CommandProtocol.Reset_InvalidPassword:
                MessageManager.instance.ShowLog("密码错误...");
                break;
            case CommandProtocol.Reset_Failed:
                MessageManager.instance.ShowLog("修改密码失败...");
                break;
            case CommandProtocol.Reset_Succeed:
                MessageManager.instance.ShowLog("修改密码成功...");
                break;
        }
    }
}
