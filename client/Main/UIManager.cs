using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject knapsackUI;
    public GameObject rankUI;
    public GameObject shopUI;
    public GameObject coin2diamondUI;
    public GameObject diamond2coinUI;
    public GameObject headerBar;
    public GameObject changeNameUI;
    public GameObject settingUI;
    public GameObject signUI;
    public GameObject mailUI;
    public GameObject noteUI;
    public GameObject rechargeUI;
    public GameObject giftUI;
    public GameObject roleUI;
    public GameObject petUI;
    public GameObject friendUI;

    // 信封相关
    public GameObject postShineBtn;
    public Sprite lightMail;
    public Sprite darkMail;
    private bool isCome = false;
    private float shineTime = 0.2f;
    private float shineTimer = 0;

    void Start()
    {
        postShineBtn.GetComponent<Button>().onClick.AddListener(delegate { OnPostBtnClick(); });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            OnMailCome();
        }

        if (isCome)  //信封闪烁
        {
            if (shineTimer >= shineTime)  //每0.2秒闪烁一次
            {
                if (postShineBtn.GetComponent<Image>().sprite == lightMail)
                {
                    postShineBtn.GetComponent<Image>().sprite = darkMail;
                }
                else
                {
                    postShineBtn.GetComponent<Image>().sprite = lightMail;
                }

                shineTimer = 0;
            }
            shineTimer += Time.deltaTime;
        }
    }

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

    public void OnShopBtnClick()
    {
        shopUI.SetActive(true);
    }

    public void OnShopCloseBtnClick()
    {
        shopUI.SetActive(false);
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

    public void OnNoteBtnClick()
    {
        noteUI.SetActive(true);
    }

    public void OnNoteCloseBtnClick()
    {
        noteUI.SetActive(false);
    }

    public void OnRechargeBtnClick()
    {
        rechargeUI.SetActive(true);
    }

    public void OnRechargeCloseBtnClick()
    {
        rechargeUI.SetActive(false);
    }

    public void OnGiftBtnClick()
    {
        giftUI.SetActive(true);
    }

    public void OnGiftCloseBtnClick()
    {
        giftUI.SetActive(false);
    }

    public void OnRoleBtnClick()
    {
        roleUI.SetActive(true);
    }

    public void OnRoleCloseBtnClick()
    {
        roleUI.SetActive(false);
    }

    public void OnPetBtnClick()
    {
        petUI.SetActive(true);
    }

    public void OnPetCloseBtnClick()
    {
        petUI.SetActive(false);
    }

    public void OnFriendBtnClick()
    {
        friendUI.SetActive(true);
    }

    public void OnFriendCloseBtnClick()
    {
        friendUI.SetActive(false);
    }

    // 当有信封来
    public void OnMailCome()
    {
        postShineBtn.SetActive(true);
        isCome = true;
    }

    public void OnPostBtnClick()
    {
        postShineBtn.SetActive(false);
        isCome = false;
    }
}
