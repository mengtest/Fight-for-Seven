using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MailItemUI : MonoBehaviour
{
    public Image bgImage;
    public Text infoText;

    public int id;

    public void UpdateBg(bool b)
    {
        if (b)  //已阅
        {
            bgImage.sprite = Resources.Load("images/4001", new Sprite().GetType()) as Sprite;
        }
    }

    public void UpdateInfo(string info)
    {
        infoText.text = info;
    }
}
