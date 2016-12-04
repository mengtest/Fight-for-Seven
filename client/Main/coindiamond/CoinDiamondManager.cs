using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinDiamondManager : MonoBehaviour
{
    public Text coinEqualText;  //金币可换钻石的数量
    public Text diamondEqualText;  //钻石可换金币的数量
    public InputField coinInput;
    public InputField diamondInput;

    private int coinCount = 0;
    private int diamondCount = 0;
    private const int coin2diamondPer = 150;  //金币：钻石=150：1
    private const int diamond2coinPer = 100;  //钻石：金币=1：100

    public void OnCoinValueChange()
    {
        if (coinInput.text == "")
        {
            diamondCount = 0;
        }
        else
        {
            coinCount = int.Parse(coinInput.text);
            diamondCount = coinCount / coin2diamondPer;
        }
        coinEqualText.text = "=" + diamondCount;
    }

    public void OnDiamondValueChange()
    {
        if (diamondInput.text == "")
        {
            coinCount = 0;
        }
        else
        {
            diamondCount = int.Parse(diamondInput.text);
            coinCount = diamondCount * diamond2coinPer;
        }
        diamondEqualText.text = "=" + coinCount;
    }

    public void OnCoinConfirmBtnClick()
    {
        if (diamondCount <= 0)
        {
            MessageManager.instance.ShowLog("请重新输入数量...");
            return;
        }
        else
        {
            bool isSuccess = PlayerInfo.Instance.BuyThingByCoin(coinCount);
            if (isSuccess)
            {
                PlayerInfo.Instance.UpdateDiamond(diamondCount);
                CoinDiamondUI.Instance.UpdateCoin(PlayerInfo.Instance.CoinCount);  //更新UI
                CoinDiamondUI.Instance.UpdateDiamond(PlayerInfo.Instance.DiamondCount);
                MessageManager.instance.ShowLog("兑换成功");
            }
            else
            {
                MessageManager.instance.ShowLog("兑换失败");
            }
        }
        ClearCoinUI();
    }

    public void OnDiamondComfirmBtnClick()
    {
        if (coinCount <= 0)
        {
            MessageManager.instance.ShowLog("请重新输入数量...");
            return;
        }
        else
        {
            bool isSuccess = PlayerInfo.Instance.BuyThingByDiamond(diamondCount);
            if (isSuccess)
            {
                PlayerInfo.Instance.UpdateCoin(coinCount);
                CoinDiamondUI.Instance.UpdateCoin(PlayerInfo.Instance.CoinCount);  //更新UI
                CoinDiamondUI.Instance.UpdateDiamond(PlayerInfo.Instance.DiamondCount);
                MessageManager.instance.ShowLog("兑换成功");
            }
            else
            {
                MessageManager.instance.ShowLog("兑换失败");
            }
        }
        ClearDiamondUI();
    }

    void ClearCoinUI()
    {
        coinCount = 0;
        diamondCount = 0;
        coinEqualText.text = "";
        coinInput.text = "";
    }

    void ClearDiamondUI()
    {
        coinCount = 0;
        diamondCount = 0;
        diamondEqualText.text = "";
        diamondInput.text = "";
    }
}
