using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoleUI : MonoBehaviour
{
    private static RoleUI instance;
    public static RoleUI Instance { get { return instance; } }

    public Text usernameText;
    public Image roleImage;
    public Sprite[] roleSprites;

    void Awake()
    {
        instance = this;
    }

    public void UpdateUsername(string username)
    {
        usernameText.text = username;
    }

    public void UpdateRoleImage(int index)
    {
        switch (index)
        {
            case 1000:
                roleImage.sprite = roleSprites[0];
                break;
            case 1001:
                roleImage.sprite = roleSprites[1];
                break;
            case 1002:
                roleImage.sprite = roleSprites[2];
                break;
            case 1003:
                roleImage.sprite = roleSprites[3];
                break;
        }
    }
}
