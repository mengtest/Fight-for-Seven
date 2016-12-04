using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class SignUI : MonoBehaviour
{
    public Text dateTimeText;
    public Button signButton;

    void Update()
    {
        DateTime now = DateTime.Now;
        dateTimeText.text = now.Year + "年" + (now.Month + 1) + "月" + now.Day + "日\n"
            + now.Hour + "时" + now.Minute + "分" + now.Second + "秒";
    }

    public void OnSignBtnClick()
    {
        SignItem item;
        int day = DateTime.Now.Day;
        SignManager.Instance.itemDict.TryGetValue(day, out item);
        if (item.isSign == false)
        {
            SignItemUI itemUI;
            SignManager.Instance.itemUIDict.TryGetValue(day, out itemUI);
            itemUI.ShowSign();

            item.UpdateSign(true);
            MessageManager.instance.ShowLog("成功签到！！！");
            signButton.interactable = false;
        }
    }
}
