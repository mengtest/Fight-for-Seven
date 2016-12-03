using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatItemUI : MonoBehaviour
{
    public Text contentText;
    public Text usernameText;

    public void UpdateConent(string content)
    {
        contentText.text = content;
    }

    public void UpdateUsername(string username)
    {
        usernameText.text = username;
    }
}
