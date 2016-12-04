using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinDiamondUI : MonoBehaviour
{
    private static CoinDiamondUI instance;
    public static CoinDiamondUI Instance { get { return instance; } }
    public Text coinText;
    public Text diamondText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateCoin(PlayerInfo.Instance.CoinCount);
        UpdateDiamond(PlayerInfo.Instance.DiamondCount);
    }

    public void UpdateCoin(int coinCount)
    {
        coinText.text = coinCount.ToString();
    }

    public void UpdateDiamond(int diamondCount)
    {
        diamondText.text = diamondCount.ToString();
    }
}
