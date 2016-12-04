using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemUI : MonoBehaviour
{
    public Image icon;
    public Text count;


    public void UpdateIcon(int index)
    {
        Sprite sprite = Resources.Load("images/" + index, new Sprite().GetType()) as Sprite;
        if (sprite != null)
        {
            icon.sprite = sprite;
        }
    }

    public void UpdateCount(int count)
    {
        if (count == 1)
        {
            this.count.text = "";
        }
        else
        {
            this.count.text = count.ToString();
        }
    }
}
