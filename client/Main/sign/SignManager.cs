using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class SignManager : MonoBehaviour
{
    private static SignManager instance;
    public static SignManager Instance { get { return instance; } }

    public GameObject signItemPrefab;
    public GameObject signSumItemPrefab;
    public Transform signItemParent;
    public Transform signSumItemParent;

    public Dictionary<int, SignItem> itemDict = new Dictionary<int, SignItem>();
    public Dictionary<int, SignItemUI> itemUIDict = new Dictionary<int, SignItemUI>();
    private List<SumSignItem> sumItemList = new List<SumSignItem>();

    private int days;  //天数
    private int from;  //从第一天的星期数开始，0代表星期日...0 1 2 3 4 5 6...

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Load();

        GetDayInfo();  //获取当月信息
        UpdateSignUI(from, from + days);  //开始加载
        UpdateSumSignUI();
    }

    void Load()
    {
        // TODO从服务器加载信息

        for (int i = 0; i < 30; i++)
        {

        }

        //模拟信息
        SumSignItem item1 = new SumSignItem(1, 1000, true);
        sumItemList.Add(item1);
        SumSignItem item2 = new SumSignItem(5, 2000, true);
        sumItemList.Add(item2);
        SumSignItem item3 = new SumSignItem(10, 2001, true);
        sumItemList.Add(item3);
        SumSignItem item4 = new SumSignItem(15, 2002, true);
        sumItemList.Add(item4);
        SumSignItem item5 = new SumSignItem(20, 3000, true);
        sumItemList.Add(item5);
        SumSignItem item6 = new SumSignItem(25, 1000, true);
        sumItemList.Add(item6);
    }

    public void UpdateSignUI(int start, int end)
    {
        int day = 0;

        //假设某月第一天为星期六，共有30天
        //则下标从5之前置空，6-35显示日期

        //将之前的置空
        for(int i = 0; i < start; ++i)
        {
            GameObject temp = Instantiate(signItemPrefab);
            temp.transform.SetParent(signItemParent);
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = Vector3.one;

            temp.GetComponent<SignItemUI>().Hide();
        }
        
        //显示日期
        for (int i = start; i < end; ++i)
        {
            GameObject temp = Instantiate(signItemPrefab);
            temp.transform.SetParent(signItemParent);
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = Vector3.one;

            temp.GetComponent<SignItemUI>().UpdateDay(++day);

            SignItem item = new SignItem(day, false);  //构造item，存储信息
            itemDict.Add(day, item);
            itemUIDict.Add(day, temp.GetComponent<SignItemUI>());
        }
    }

    public void UpdateSumSignUI()
    {
        for (int i = 0; i < sumItemList.Count; ++i)
        {
            GameObject temp = Instantiate(signSumItemPrefab);
            temp.transform.SetParent(signSumItemParent);
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = Vector3.one;

            temp.GetComponent<SignSumItemUI>().UpdateDay(sumItemList[i].sumDay);
            temp.GetComponent<SignSumItemUI>().UpdateImage(sumItemList[i].spriteIndex);
        }
    }

    void GetDayInfo()
    {
        DateTime now = DateTime.Now;

        from = (int)new DateTime(now.Year, now.Month, 1).DayOfWeek;  //获取第一天是星期几，需要先构造第一天

        days = DateTime.DaysInMonth(now.Year, now.Month);  //获取这个月的天数
    }
}
