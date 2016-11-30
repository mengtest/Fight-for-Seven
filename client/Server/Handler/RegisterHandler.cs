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
            return TypeProtocol.TYPE_REGISTER;
        }
    }

    public override void Dispatch(int command, List<String> message)
    {
        switch (command)
        {
            case CommandProtocol.Register_InvalidMessage:
                MessageManager.instance.ShowLog("请重新注册...");
                break;
            case CommandProtocol.Register_InvalidAccount:
                MessageManager.instance.ShowLog("账号已存在...");
                break;
            case CommandProtocol.Register_Failed:
                MessageManager.instance.ShowLog("注册失败...");
                break;
            case CommandProtocol.Register_Succeed:
                MessageManager.instance.ShowLog("注册成功...");
                break;
        }
    }
}
