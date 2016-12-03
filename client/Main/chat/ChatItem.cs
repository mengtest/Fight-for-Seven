using UnityEngine;
using System.Collections;

public enum ChatType
{
    World,
    System
}

public class ChatItem
{
    public string username;
    public string content;
    public ChatType chatType;

    public ChatItem(string username, string content, ChatType chatType)
    {
        this.username = username;
        this.content = content;
        this.chatType = chatType;
    }
}
