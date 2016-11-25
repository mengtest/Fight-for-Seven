using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RegisterHandler : BaseHandler
{
    public override int type
    {
        get
        {
            return Protocol.TYPE_REGISTER;
        }
    }

    public override void Dispatch(int command, List<String> message)
    {
        switch (command)
        {
            case RegisterProtocol.Register_InvalidMessage:
                MessageManager.instance.ShowLog("请重新注册...");
                break;
            case RegisterProtocol.Register_InvalidAccount:
                MessageManager.instance.ShowLog("账号已存在...");
                break;
            case RegisterProtocol.Register_Failed:
                MessageManager.instance.ShowLog("注册失败...");
                break;
            case RegisterProtocol.Register_Succeed:
                MessageManager.instance.ShowLog("注册成功...");
                break;
        }
    }
}
