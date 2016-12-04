using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignSumItemUI : MonoBehaviour
{
    public Text dayText;
    public Image signImage;

    public void UpdateDay(int day)
    {
        dayText.text = day.ToString() + "天";
    }

    public void UpdateImage(int spriteIndex)
    {
        signImage.sprite = Resources.Load("images/" + spriteIndex, new Sprite().GetType()) as Sprite;
    }

    public void Hide()
    {
        dayText.text = "";
        signImage.sprite = null;
    }
}
