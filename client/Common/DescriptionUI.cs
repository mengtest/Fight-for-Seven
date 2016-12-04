using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DescriptionUI : MonoBehaviour
{
    public Text outlineText;
    public Text contentlineText;

    public void UpdateDes(string text)
    {
        outlineText.text = text;
        contentlineText.text = text;
    }

    public void ShowDes()
    {
        gameObject.SetActive(true);
    }

    public void HideDes()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector2 position)
    {
        transform.localPosition = position;
    }
}
