using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public InputField accountText_login;
    public InputField passwordText_login;
    public Button loginBtn;

    public InputField accountText_register;
    public InputField passwordText_register;
    public InputField passwordText_again_register;
    public Button registerBtn;

    public InputField accountText_reset;
    public InputField passwordText_reset;
    public InputField passwordText_new_reset;
    public Button resetBtn;

    public Button clickToRegister;
    public Button clickToReset;
    public Button clickToAbout;

    public GameObject registerBoard;
    public GameObject resetBoard;

    public void OnLoginBtnClick()
    {
        string account = accountText_login.text;
        string password = passwordText_login.text;

        if (account.Length < 3 || account.Length > 10)
        {
            MessageManager.instance.ShowLog("账号不符合要求...");
            return;
        }
        else if (password.Length < 3 || password.Length > 10)
        {
            MessageManager.instance.ShowLog("密码不符合要求...");
            return;
        }
        else
        {
            SocketModel loginRequset = new SocketModel();
            loginRequset.SetType(Protocol.TYPE_LOGIN);
            loginRequset.SetArea(LoginProtocol.Area_LoginRequest);
            loginRequset.SetCommand(0);
            List<string> message = new List<string>();
            message.Add(account);
            message.Add(password);
            loginRequset.SetMessage(message);
            MainClient.Instance.SendMsg(loginRequset);
        }
    }

    public void OnRegisterBtnClick()
    {
        string account = accountText_register.text;
        string password = passwordText_register.text;
        string password_again = passwordText_again_register.text;

        if (account.Length < 3 || account.Length > 10)
        {
            MessageManager.instance.ShowLog("账号不符合要求...");
            return;
        }
        else if (password.Length < 3 || password.Length > 10)
        {
            MessageManager.instance.ShowLog("密码不符合要求...");
            return;
        }
        else if (password != password_again)
        {
            MessageManager.instance.ShowLog("两次输入的密码不一致...");
            return;
        }
        else
        {
            SocketModel registerRequset = new SocketModel();
            registerRequset.SetType(Protocol.TYPE_REGISTER);
            registerRequset.SetArea(RegisterProtocol.Area_RegisterRequest);
            registerRequset.SetCommand(0);
            List<string> message = new List<string>();
            message.Add(account);
            message.Add(password);
            registerRequset.SetMessage(message);
            MainClient.Instance.SendMsg(registerRequset);
        }
    }

    public void OnResetBtnClick()
    {
        string account = accountText_reset.text;
        string password = passwordText_reset.text;
        string password_new = passwordText_new_reset.text;

        if (account.Length < 3 || account.Length > 10)
        {
            MessageManager.instance.ShowLog("账号不符合要求...");
            return;
        }
        else if (password.Length < 3 || password.Length > 10)
        {
            MessageManager.instance.ShowLog("密码不符合要求...");
            return;
        }
        else if (password_new.Length < 3 || password_new.Length > 10)
        {
            MessageManager.instance.ShowLog("新密码不符合要求...");
            return;
        }
        else if (password == password_new)
        {
            MessageManager.instance.ShowLog("请输入新密码...");
            return;
        }
        else
        {
            SocketModel resetRequset = new SocketModel();
            resetRequset.SetType(Protocol.TYPE_RESET);
            resetRequset.SetArea(ResetProtocol.Area_ResetRequest);
            resetRequset.SetCommand(0);
            List<string> message = new List<string>();
            message.Add(account);
            message.Add(password);
            message.Add(password_new);
            resetRequset.SetMessage(message);
            MainClient.Instance.SendMsg(resetRequset);
        }
    }

    public void OnClickToRegister()
    {
        registerBoard.SetActive(true);
    }

    public void OnClickToReset()
    {
        resetBoard.SetActive(true);
    }

    public void OnClickToAbout()
    {
        Application.OpenURL("www.littleredhat1997.com");
    }

    public void OnCancelResisterBtnClick()
    {
        accountText_register.text = "";
        passwordText_register.text = "";
        passwordText_again_register.text = "";
        registerBoard.SetActive(false);
    }

    public void OnCancelResetBtnClick()
    {
        accountText_reset.text = "";
        passwordText_reset.text = "";
        passwordText_new_reset.text = "";
        resetBoard.SetActive(false);
    }
}
