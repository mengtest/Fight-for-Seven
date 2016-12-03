using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatManager : MonoBehaviour
{
    private static ChatManager instance;
    public static ChatManager Instance { get { return instance; } }

    public List<ChatItemUI> itemUIList = new List<ChatItemUI>();

    void Awake()
    {
        instance = this;
    }
}
