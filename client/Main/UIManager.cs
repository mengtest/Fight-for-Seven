using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject knapsackUI;
    public GameObject rankUI;
    public GameObject coin2diamondUI;
    public GameObject diamond2coinUI;
    public GameObject headerBar;
    public GameObject changeNameUI;
    public GameObject settingUI;
    public GameObject signUI;
    public GameObject mailUI;

    public void OnKnapsacBtnClick()
    {
        knapsackUI.SetActive(true);
    }

    public void OnKnapsacCloseBtnClick()
    {
        knapsackUI.SetActive(false);
    }

    public void OnRankBtnClick()
    {
        rankUI.SetActive(true);
    }

    public void OnRankBtnCloseBtnClick()
    {
        rankUI.SetActive(false);
    }

    public void OnAddCoinBtnClick()
    {
        diamond2coinUI.SetActive(true);
    }

    public void OnAddDiamondBtnClick()
    {
        coin2diamondUI.SetActive(true);
    }

    public void OnAddCoinCloseBtnClick()
    {
        diamond2coinUI.SetActive(false);
    }

    public void OnAddDiamondCloseBtnClick()
    {
        coin2diamondUI.SetActive(false);
    }

    public void OnHeaderBtnClick()
    {
        if (headerBar.activeInHierarchy)
        {
            headerBar.SetActive(false);
        }
        else
        {
            headerBar.SetActive(true);
        }
    }

    public void OnChangeNameBtnClick()
    {
        changeNameUI.SetActive(true);
    }

    public void OnChangeNameCloseBtnClick()
    {
        changeNameUI.SetActive(false);
    }

    public void OnSettingBtnClick()
    {
        settingUI.SetActive(true);
    }

    public void OnSettingCloseBtnClick()
    {
        settingUI.SetActive(false);
    }

    public void OnSignBtnClick()
    {
        signUI.SetActive(true);
    }

    public void OnSignCloseBtnClick()
    {
        signUI.SetActive(false);
    }

    public void OnMailBtnClick()
    {
        mailUI.SetActive(true);
    }

    public void OnMailCloseBtnClick()
    {
        mailUI.SetActive(false);
    }
}
