using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Image role;
    public Sprite[] roles;
    public Text username;
    private int num = 0;

    void Awake()
    {
        instance = this;
    }

    public void SetRole(int index, string name)
    {
        switch (index)
        {
            case 1000:
                role.sprite = roles[0];
                break;
            case 1001:
                role.sprite = roles[1];
                break;
            case 1002:
                role.sprite = roles[2];
                break;
            case 1003:
                role.sprite = roles[3];
                break;
            default:
                break;
        }
        username.text = name;
    }

    //int[] indexs = { 1000, 2000, 2001, 2002, 3000 };  //测试

    public void OnTestBtnClick()
    {
        //         KnapsackManager.Instance.StoreItem(indexs[num]);
        //         ++num;
        //         num %= indexs.Length;
        MailItem item = new MailItem(++num, num.ToString(), "I am " + num, "Hello, I am " + num, false, MailType.Friend);
        MailManager.Instance.GetMail(item);
    }
}
