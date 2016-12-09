using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyUI : MonoBehaviour
{
    private static BuyUI instance;
    public static BuyUI Instance { get { return instance; } }

    // 购买界面
    public GameObject buyPanel;
    public Button reduceBtn;
    public Button addBtn;
    public InputField countText;
    public Text priceText;
    public Image typeIcon;  // 金币或者钻石图标

    private int count;
    private int unitPrice;  // 单价
    private int totalPrice;  // 总价
    private PaymentType type;  // 金币还是钻石

    void Awake()
    {
        instance = this;
    }

    public void ShowBuyInfo(ShopItem item)
    {
        type = item.paymentType;
        switch (type)
        {
            case PaymentType.Coin:
                typeIcon.sprite = Resources.Load("images/6002", new Sprite().GetType()) as Sprite;
                break;
            case PaymentType.Diamond:
                typeIcon.sprite = Resources.Load("images/6003", new Sprite().GetType()) as Sprite;
                break;
            default:
                break;
        }

        countText.text = "1";
        count = 1;

        priceText.text = item.buyPrice.ToString();
        unitPrice = item.buyPrice;
        totalPrice = unitPrice;
    }

    public void ClearBuyInfo()
    {
        count = 0;
        unitPrice = 0;
        totalPrice = 0;
    }

    public void OnReduceBtnClick()  // 减少商品数量
    {
        count = int.Parse(countText.text);
        if (count == 0)  // 数量必须为正数
        {
            MessageManager.instance.ShowLog("不能再小啦！！！");
            return;
        }
        else
        {
            --count;
            countText.text = count.ToString();

            totalPrice = count * unitPrice;
            priceText.text = totalPrice.ToString();
        }
    }

    public void OnAddBtnClick()  // 增加商品数量
    {
        count = int.Parse(countText.text);
        if (count == 99)  // 数量不得超过999
        {
            MessageManager.instance.ShowLog("不能再大啦！！！");
            return;
        }
        else
        {
            ++count;
            countText.text = count.ToString();

            totalPrice = count * unitPrice;
            priceText.text = totalPrice.ToString();
        }
    }

    public void OnValueChange()
    {
        if (countText.text == string.Empty)  // 防止输入时候转换错误
        {
            return;
        }

        count = int.Parse(countText.text);
        if (count < 0)  // 数量必须为正数
        {
            count = 0;
            MessageManager.instance.ShowLog("不能再小啦！！！");
        }
        else if (count > 99)  // 数量不得超过999
        {

            count = 99;
            MessageManager.instance.ShowLog("不能再大啦！！！");
        }

        countText.text = count.ToString();

        totalPrice = count * unitPrice;
        priceText.text = totalPrice.ToString();
    }

    public void OnBuyBtnClick()
    {
        if (count == 0)
        {
            MessageManager.instance.ShowLog("少侠你买还是不买...");
            return;
        }

        bool isSuccess = false;
        switch (type)
        {
            case PaymentType.Coin:
                isSuccess = PlayerInfo.Instance.BuyThingByCoin(totalPrice);
                if (isSuccess)
                {
                    MessageManager.instance.ShowLog("购买成功，共花费" + totalPrice + "金币");
                }
                else
                {
                    MessageManager.instance.ShowLog("购买失败，还差" + (totalPrice - PlayerInfo.Instance.CoinCount) + "金币");
                }
                break;
            case PaymentType.Diamond:
                isSuccess = PlayerInfo.Instance.BuyThingByDiamond(totalPrice);
                if (isSuccess)
                {
                    MessageManager.instance.ShowLog("购买成功，共花费" + totalPrice + "钻石");
                }
                else
                {
                    MessageManager.instance.ShowLog("购买失败，还差" + (totalPrice - PlayerInfo.Instance.DiamondCount) + "钻石");
                }
                break;
            default:
                break;
        }
    }
}
