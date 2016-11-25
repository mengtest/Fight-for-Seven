using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CreateHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return Protocol.TYPE_CREATE;
        }
    }

    public override void Dispatch(int command, List<string> message)
    {
        switch (command)
        {
            case CreateProtocol.Create_InvalidMessage:
                MessageManager.instance.ShowLog("请重新按确认键...");
                break;
            case CreateProtocol.Create_Failed:
                MessageManager.instance.ShowLog("创建失败...");
                break;
            case CreateProtocol.Create_Succeed:
                MessageManager.instance.ShowLog("创建成功...");
                break;
        }
    }
}
