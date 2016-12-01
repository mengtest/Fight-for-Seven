using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeNameManager : MonoBehaviour
{
    public InputField changeNameInput;

    public void OnConfirmClick()
    {
        string username = changeNameInput.text;
        if (username.Length < 3 || username.Length > 10)
        {
            MessageManager.instance.ShowLog("用户名不合法");
        }
        else
        {
            //发送给服务端TODO

            PlayerInfo.Instance.UpdateUsername(username);
            RoleUI.Instance.UpdateUsername(username);
            changeNameInput.text = "";
        }
    }
}
