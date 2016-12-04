using UnityEngine;
using System.Collections;

public class DragItemUI : ItemUI
{

    public void ShowItem()
    {
        gameObject.SetActive(true);
    }

    public void HideItem()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector2 position)
    {
        transform.localPosition = position;
    }
}
