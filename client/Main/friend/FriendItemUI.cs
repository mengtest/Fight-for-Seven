using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FriendItemUI : MonoBehaviour
{
    public Image friendHeader;
    public Text friendUsername;

    private FriendItem itemInfo;
    public FriendItem ItemInfo
    {
        get
        {
            return itemInfo;
        }
    }

    public void UpdateHeader(int headerIndex)
    {
        Sprite header = Resources.Load("images/" + headerIndex, new Sprite().GetType()) as Sprite;
        friendHeader.sprite = header;
    }

    public void UpdateUsername(string username)
    {
        friendUsername.text = username;
    }

    public void SetFriendInfo(FriendItem item)
    {
        itemInfo = item;
    }
}
