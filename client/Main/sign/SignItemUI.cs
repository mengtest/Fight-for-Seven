using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignItemUI : MonoBehaviour
{
    public Text dayText;
    public Image signImage;

    public void UpdateDay(int day)
    {
        dayText.text = day.ToString();
    }

    public void ShowSign()
    {
        signImage.gameObject.SetActive(true);
    }

    public void Hide()
    {
        dayText.text = "";
        signImage.sprite = null;
    }
}
