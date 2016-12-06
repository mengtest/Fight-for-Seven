using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopUI : MonoBehaviour
{
    private static ShopUI instance;
    public static ShopUI Instance { get { return instance; } }

    public Sprite unselectSprite;
    public Sprite selectSprite;
    public Image petImage;
    public Image dressImage;
    public Image consumableImage;
    public GameObject gridPanel;
    public GameObject buyPanel;
    public GameObject girlImage;
    public GameObject leftBtnGo;
    public GameObject rightBtnGo;

    private ItemType type;
    private const int gridCount = 8;
    private int from = 0;
    private int to = gridCount;

    void Awake()
    {
        instance = this;
    }

    // 当商城宠物按钮被按下
    public void OnPetBtnClick()
    {
        type = ItemType.Pet;
        SetState();
        //改变样式
        petImage.sprite = selectSprite;
        dressImage.sprite = unselectSprite;
        consumableImage.sprite = unselectSprite;

        if (to < ShopManager.Instance.petLength)  //榜上数量较多
        {
            rightBtnGo.SetActive(true);
        }
        else  //少于10人则按少的计数
        {
            to = ShopManager.Instance.petLength;
            rightBtnGo.SetActive(false);
        }
        ShopManager.Instance.LoadPet(from, to);
    }

    // 当商城时装按钮被按下
    public void OnDressBtnClick()
    {
        type = ItemType.Dress;
        SetState();
        //改变样式
        petImage.sprite = unselectSprite;
        dressImage.sprite = selectSprite;
        consumableImage.sprite = unselectSprite;

        if (to < ShopManager.Instance.dressLength)  //榜上数量较多
        {
            rightBtnGo.SetActive(true);
        }
        else  //少于10人则按少的计数
        {
            to = ShopManager.Instance.dressLength;
            rightBtnGo.SetActive(false);
        }
        ShopManager.Instance.LoadDress(from, to);
    }

    // 当商城消耗品按钮被按下
    public void OnConsumablesBtnClick()
    {
        type = ItemType.Consumable;
        SetState();
        //改变样式
        petImage.sprite = unselectSprite;
        dressImage.sprite = unselectSprite;
        consumableImage.sprite = selectSprite;

        if (to < ShopManager.Instance.consumableLength)  //榜上数量较多
        {
            rightBtnGo.SetActive(true);
        }
        else  //少于10人则按少的计数
        {
            to = ShopManager.Instance.consumableLength;
            rightBtnGo.SetActive(false);
        }
        ShopManager.Instance.LoadConsumable(from, to);
    }

    void SetState()
    {
        from = 0;
        to = gridCount;
        gridPanel.SetActive(true);
        leftBtnGo.SetActive(false);
        rightBtnGo.SetActive(false);
        girlImage.SetActive(false);
    }

    public void OnLeftBtnClick()
    {
        //此时右键肯定可以按下，左键则不一定
        rightBtnGo.SetActive(true);
        leftBtnGo.SetActive(true);

        to = from;  //从上次的开始作为结束
        from = to - gridCount;
        if (from == 0)  //判断是否等于0
        {
            leftBtnGo.SetActive(false);
        }
        switch (type)
        {
            case ItemType.Pet:
                ShopManager.Instance.LoadPet(from, to);
                break;
            case ItemType.Dress:
                ShopManager.Instance.LoadDress(from, to);
                break;
            case ItemType.Consumable:
                ShopManager.Instance.LoadConsumable(from, to);
                break;
            default:
                break;
        }
    }

    public void OnRigtBtnClick()
    {
        //此时左键肯定可以按，右键不一定
        leftBtnGo.SetActive(true);
        rightBtnGo.SetActive(true);

        from = to;  //从上次末尾开始
        to = to + gridCount;
        switch (type)
        {
            case ItemType.Pet:
                //判断是否超出榜上人数
                if (to >= ShopManager.Instance.petLength)  //超出则不能再按右键
                {
                    to = ShopManager.Instance.petLength;
                    rightBtnGo.SetActive(false);
                }
                ShopManager.Instance.LoadPet(from, to);
                break;
            case ItemType.Dress:
                if (to >= ShopManager.Instance.dressLength)
                {
                    to = ShopManager.Instance.dressLength;
                    rightBtnGo.SetActive(false);
                }
                ShopManager.Instance.LoadDress(from, to);
                break;
            case ItemType.Consumable:
                if (to >= ShopManager.Instance.consumableLength)
                {
                    to = ShopManager.Instance.consumableLength;
                    rightBtnGo.SetActive(false);
                }
                ShopManager.Instance.LoadConsumable(from, to);
                break;
            default:
                break;
        }
    }

    public void ShowBuyInfo(ShopItem item)  // 帮忙唤醒
    {
        buyPanel.SetActive(true);
        BuyUI.Instance.ShowBuyInfo(item);
    }

    public void OnBuyCloseBtnClick()
    {
        buyPanel.SetActive(false);
        BuyUI.Instance.ClearBuyInfo();
    }
}
