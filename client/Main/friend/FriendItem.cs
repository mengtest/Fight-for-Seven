using UnityEngine;
using System.Collections;

public class FriendItem
{
    public string friendAccount;
    public int friendHeader;
    public int friendTitle;
    public int logoutTime;
    public string friendUsername;

    public FriendItem(string friendAccount, int friendHeader, int friendTitle, int logoutTime, string friendUsername)
    {
        this.friendAccount = friendAccount;
        this.friendHeader = friendHeader;
        this.friendTitle = friendTitle;
        this.logoutTime = logoutTime;
        this.friendUsername = friendUsername;
    }
}
