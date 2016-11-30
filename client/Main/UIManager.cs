using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject knapsackUI;

    public void OnKnapsacBtnClick()
    {
        knapsackUI.SetActive(true);
    }

    public void OnKnapsacCloseBtnClick()
    {
        knapsackUI.SetActive(false);
    }
}
