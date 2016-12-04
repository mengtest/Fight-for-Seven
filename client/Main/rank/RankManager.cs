using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RankManager : MonoBehaviour
{
    private static RankManager instance;
    public static RankManager Instance { get { return instance; } }
    public RankItemUI[] rankItemUI;
    public int competitionLength;
    public int wealthLength;
    public int charmLength;

    private List<Rank> competitionList = new List<Rank>();
    private List<Rank> wealthList = new List<Rank>();
    private List<Rank> charmList = new List<Rank>();

    private const int pageLength = 10;

    void Awake()
    {
        instance = this;

        Load();
        competitionLength = competitionList.Count;
        wealthLength = wealthList.Count;
        charmLength = charmList.Count;
    }

    //模拟加载数据，将来从服务器获取
    private void Load()
    {
        /*** 竞赛 ***/
        Rank c1 = new Rank(1, "111", "aaa", "胜场：1000   败场：100");
        Rank c2 = new Rank(2, "222", "bbb", "胜场：999   败场：100");
        Rank c3 = new Rank(3, "333", "ccc", "胜场：900   败场：100");
        Rank c4 = new Rank(4, "444", "ddd", "胜场：888   败场：100");
        Rank c5 = new Rank(5, "555", "eee", "胜场：800   败场：100");
        Rank c6 = new Rank(6, "666", "fff", "胜场：777   败场：100");
        Rank c7 = new Rank(7, "777", "ggg", "胜场：700   败场：100");
        Rank c8 = new Rank(8, "888", "hhh", "胜场：666   败场：100");
        Rank c9 = new Rank(9, "999", "iii", "胜场：600   败场：100");
        Rank c10 = new Rank(10, "0000", "jjj", "胜场：555   败场：100");
        Rank c11 = new Rank(11, "1111", "kkk", "胜场：500   败场：100");
        Rank c12 = new Rank(12, "2222", "lll", "胜场：444   败场：100");
        Rank c13 = new Rank(13, "3333", "mmm", "胜场：400   败场：100");
        Rank c14 = new Rank(14, "4444", "nnn", "胜场：333   败场：100");
        Rank c15 = new Rank(15, "5555", "ooo", "胜场：300   败场：100");
        Rank c16 = new Rank(16, "6666", "ppp", "胜场：222   败场：100");
        Rank c17 = new Rank(17, "7777", "qqq", "胜场：200   败场：100");
        Rank c18 = new Rank(18, "8888", "rrr", "胜场：111   败场：100");
        Rank c19 = new Rank(19, "9999", "sss", "胜场：100   败场：100");
        Rank c20 = new Rank(20, "00000", "ttt", "胜场：99   败场：100");
        Rank c21 = new Rank(21, "11111", "uuu", "胜场：55   败场：100");
        Rank c22 = new Rank(22, "22222", "vvv", "胜场：11   败场：100");

        competitionList.Add(c1);
        competitionList.Add(c2);
        competitionList.Add(c3);
        competitionList.Add(c4);
        competitionList.Add(c5);
        competitionList.Add(c6);
        competitionList.Add(c7);
        competitionList.Add(c8);
        competitionList.Add(c9);
        competitionList.Add(c10);
        competitionList.Add(c11);
        competitionList.Add(c12);
        competitionList.Add(c13);
        competitionList.Add(c14);
        competitionList.Add(c15);
        competitionList.Add(c16);
        competitionList.Add(c17);
        competitionList.Add(c18);
        competitionList.Add(c19);
        competitionList.Add(c20);
        competitionList.Add(c21);
        competitionList.Add(c22);

        /*** 财富 ***/
        Rank w1 = new Rank(1, "111", "aaa", "钻石：1000   金币：100");
        Rank w2 = new Rank(2, "222", "bbb", "钻石：999   金币：100");
        Rank w3 = new Rank(3, "333", "ccc", "钻石：900   金币：100");
        Rank w4 = new Rank(4, "444", "ddd", "钻石：888   金币：100");
        Rank w5 = new Rank(5, "555", "eee", "钻石：800   金币：100");
        Rank w6 = new Rank(6, "666", "fff", "钻石：777   金币：100");
        Rank w7 = new Rank(7, "777", "ggg", "钻石：700   金币：100");
        Rank w8 = new Rank(8, "888", "hhh", "钻石：666   金币：100");
        Rank w9 = new Rank(9, "999", "iii", "钻石：600   金币：100");
        Rank w10 = new Rank(10, "0000", "jjj", "钻石：555   金币：100");
        Rank w11 = new Rank(11, "1111", "kkk", "钻石：500   金币：100");
        Rank w12 = new Rank(12, "2222", "lll", "钻石：444   金币：100");
        Rank w13 = new Rank(13, "3333", "mmm", "钻石：400   金币：100");
        Rank w14 = new Rank(14, "4444", "nnn", "钻石：333   金币：100");
        Rank w15 = new Rank(15, "5555", "ooo", "钻石：300   金币：100");

        wealthList.Add(w1);
        wealthList.Add(w2);
        wealthList.Add(w3);
        wealthList.Add(w4);
        wealthList.Add(w5);
        wealthList.Add(w6);
        wealthList.Add(w7);
        wealthList.Add(w8);
        wealthList.Add(w9);
        wealthList.Add(w10);
        wealthList.Add(w11);
        wealthList.Add(w12);
        wealthList.Add(w13);
        wealthList.Add(w14);
        wealthList.Add(w15);

        /*** 魅力 ***/
        Rank cc1 = new Rank(1, "111", "aaa", "魅力：1000");
        Rank cc2 = new Rank(2, "222", "bbb", "魅力：999");
        Rank cc3 = new Rank(3, "333", "ccc", "魅力：900");
        Rank cc4 = new Rank(4, "444", "ddd", "魅力：888");
        Rank cc5 = new Rank(5, "555", "eee", "魅力：800");
        Rank cc6 = new Rank(6, "666", "fff", "魅力：777");
        Rank cc7 = new Rank(7, "777", "ggg", "魅力：700");
        Rank cc8 = new Rank(8, "888", "hhh", "魅力：666");

        charmList.Add(cc1);
        charmList.Add(cc2);
        charmList.Add(cc3);
        charmList.Add(cc4);
        charmList.Add(cc5);
        charmList.Add(cc6);
        charmList.Add(cc7);
        charmList.Add(cc8);
    }

    //竞赛榜
    public void LoadCompetition(int from, int to)
    {
        for (int i = from; i < to; i++)
        {
            Rank temp = competitionList[i];
            rankItemUI[i % pageLength].UpdateRank(temp.rank.ToString(), temp.username, temp.description);
        }
        SetNullState(to);
    }

    //财富榜
    public void LoadWealth(int from, int to)
    {
        for (int i = from; i < to; i++)
        {
            Rank temp = wealthList[i];
            rankItemUI[i % pageLength].UpdateRank(temp.rank.ToString(), temp.username, temp.description);
        }
        SetNullState(to);
    }

    //魅力榜
    public void LoadCharm(int from, int to)
    {
        for (int i = from; i < to; i++)
        {
            Rank temp = charmList[i];
            rankItemUI[i % pageLength].UpdateRank(temp.rank.ToString(), temp.username, temp.description);
        }
        SetNullState(to);
    }

    void SetNullState(int to)  //将不足的位置置空
    {
        if (to % pageLength != 0)
        {
            for (int i = to % pageLength; i < pageLength; i++)
            {
                rankItemUI[i % pageLength].UpdateRank("", "", "");
            }
        }
    }
}
