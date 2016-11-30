using UnityEngine;
using System.Collections;

public enum PlayerType
{
    LUOLI = 1000,
    NVWANG = 1001,
    ZHONGXING = 1002,
    FUHEI = 1003
}

public class PlayerInfo : MonoBehaviour
{
    private static PlayerInfo instance;

    public static PlayerInfo Instance
    {
        get
        {
            return instance;
        }
    }

    public int SelectIndex
    {
        get
        {
            return selectIndex;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
    }

    public int CoinCount
    {
        get
        {
            return coinCount;
        }
    }

    public int DiamondCount
    {
        get
        {
            return diamondCount;
        }
    }

    public int WinCount
    {
        get
        {
            return winCount;
        }
    }

    public int LoseCount
    {
        get
        {
            return loseCount;
        }
    }

    public string Username
    {
        get
        {
            return username;
        }
    }

    void Awake()
    {
        instance = this;
    }

    private int selectIndex = 0;  //角色下标
    private int level;  //等级
    private int coinCount;  //金币数目
    private int diamondCount;  //钻石数目
    private int winCount;  //胜利场次
    private int loseCount;  //失败场次
    private string username;

    public void UpdateLevel(int level)
    {
        this.level += level;
    }

    public void UpdateCoin(int coin)
    {
        this.coinCount += coin;
    }

    public void UpdateDiamond(int diamond)
    {
        this.diamondCount += diamond;
    }

    public void UpdateWin(int win)
    {
        this.winCount += win;
    }

    public void UpdateLose(int lose)
    {
        this.loseCount += lose;
    }

    public void UpdateUsername(string username)
    {
        this.username = username;
    }
}
