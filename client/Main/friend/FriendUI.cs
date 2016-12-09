using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FriendUI : MonoBehaviour
{
    private static FriendUI instance;
    public static FriendUI Instance { get { return instance; } }

    public GameObject friendDes;
    public Image friendHeader;
    public Image friendTitle;
    public Text usernameText;
    public Text logoutTimeText;

    void Awake()
    {
        instance = this;
    }

    public void ShowFriendDes()
    {
        friendDes.SetActive(true);
    }

    public void HideFriendDes()
    {
        friendDes.SetActive(false);
    }

    public void UpdateFriendDes(int friendHeaderIndex, int friendTitleIndex, string username, int logoutTime)
    {
        friendHeader.sprite = Resources.Load("images/" + friendHeaderIndex,new Sprite().GetType()) as Sprite;
        friendTitle.sprite = Resources.Load("images/" + friendTitleIndex, new Sprite().GetType()) as Sprite;
        usernameText.text = username;
        logoutTimeText.text = logoutTime + "天";
    }

    public void OnChatBtnClick()
    {

    }

    public void OnRemoveBtnClick()
    {

    }
}
