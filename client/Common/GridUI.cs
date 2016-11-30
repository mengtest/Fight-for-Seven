using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class GridUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region
    public static Action<Transform> OnEnter;
    public static Action OnExit;
    private string gridTag = "Grid";

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == gridTag)
        {
            if (OnEnter != null)
            {
                OnEnter(this.transform);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == gridTag)
        {
            if (OnExit != null)
            {
                OnExit();
            }
        }
    }
    #endregion

    #region
    public static Action<Transform> OnLeftBeginDrag;
    public static Action<Transform> OnLeftDrag;
    public static Action<Transform, Transform> OnLeftEndDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnLeftBeginDrag != null)
            {
                OnLeftBeginDrag(transform);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnLeftBeginDrag != null)
            {
                OnLeftDrag(transform);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnLeftBeginDrag != null)
            {
                if (eventData.pointerEnter == null)  //拖放到空地方
                {
                    OnLeftEndDrag(transform, null);
                }
                else  //拖放到UI上
                {
                    OnLeftEndDrag(transform, eventData.pointerEnter.gameObject.transform);
                }
            }
        }
    }
    #endregion
}
