using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MailManager : MonoBehaviour
{
    private static MailManager instance;
    public static MailManager Instance { get { return instance; } }

    public GameObject mailItemPrefab;
    public Transform mailItemParent;

    private List<MailItem> itemList = new List<MailItem>();
    private Dictionary<int, MailItemUI> itemUIDict = new Dictionary<int, MailItemUI>();
    private Dictionary<int, MailItem> itemDict = new Dictionary<int, MailItem>();

    private MailItemUI selectItemUI;  //当前选择的邮件物体
    private MailItem selectItem;  //当前选择的邮件信息

    void Awake()
    {
        instance = this;

        //Load();
        //UpdateMail();

        //注册事件
        GridUI.OnMailItemClick += GridUIOnMailItemClick;
    }

    //模拟从服务器加载信息
    void Load()
    {
        MailItem item1 = new MailItem(1, "111", "gm", "这是信息一...", true, MailType.GM);
        MailItem item2 = new MailItem(2, "222", "gm", "这是信息二...", false, MailType.GM);
        MailItem item3 = new MailItem(3, "333", "gm", "这是信息三...", true, MailType.GM);
        MailItem item4 = new MailItem(4, "444", "friend1", "这是信息四...", false, MailType.Friend);
        MailItem item5 = new MailItem(5, "555", "friend2", "这是信息五...", true, MailType.Friend);
        MailItem item6 = new MailItem(6, "666", "friend3", "这是信息六...", false, MailType.Friend);
        MailItem item7 = new MailItem(7, "777", "stranger1", "这是信息七...", true, MailType.Stranger);
        MailItem item8 = new MailItem(8, "777", "stranger1", "这是信息八...", false, MailType.Stranger);
        MailItem item9 = new MailItem(9, "888", "stranger2", "这是信息九...", true, MailType.Stranger);
        MailItem item10 = new MailItem(10, "888", "stranger2", "这是信息十...", false, MailType.Stranger);

        itemList.Add(item1);
        itemDict.Add(item1.mailId, item1);
        itemList.Add(item2);
        itemDict.Add(item2.mailId, item2);
        itemList.Add(item3);
        itemDict.Add(item3.mailId, item3);
        itemList.Add(item4);
        itemDict.Add(item4.mailId, item4);
        itemList.Add(item5);
        itemDict.Add(item5.mailId, item5);
        itemList.Add(item6);
        itemDict.Add(item6.mailId, item6);
        itemList.Add(item7);
        itemDict.Add(item7.mailId, item7);
        itemList.Add(item8);
        itemDict.Add(item8.mailId, item8);
        itemList.Add(item9);
        itemDict.Add(item9.mailId, item9);
        itemList.Add(item10);
        itemDict.Add(item10.mailId, item10);
    }

    void UpdateMail()
    {
        foreach (var item in itemList)
        {
            GameObject temp = Instantiate(mailItemPrefab);
            temp.transform.SetParent(mailItemParent);
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = Vector3.one;

            //更新itemUI
            temp.GetComponent<MailItemUI>().UpdateBg(item.isRead);
            temp.GetComponent<MailItemUI>().UpdateInfo(item.usernameFrom);
            temp.GetComponent<MailItemUI>().id = item.mailId;

            //保存itemUI信息
            itemUIDict.Add(item.mailId, temp.GetComponent<MailItemUI>());
        }
    }

    public void GridUIOnMailItemClick(Transform itemTransform)
    {
        //更新已阅效果
        selectItemUI = itemTransform.GetComponent<MailItemUI>();
        selectItemUI.UpdateBg(true);

        //更新邮件内容
        itemDict.TryGetValue(selectItemUI.id, out selectItem);
        MailUI.Instance.UpdateText(selectItem.content);

        //显示删除按钮
        MailUI.Instance.ShowRemoveBtn();
    }

    public void GetMail(MailItem item)
    {
        itemList.Add(item);
        itemDict.Add(item.mailId, item);

        GameObject temp = Instantiate(mailItemPrefab);
        temp.transform.SetParent(mailItemParent);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localScale = Vector3.one;

        //更新itemUI
        temp.GetComponent<MailItemUI>().UpdateBg(item.isRead);
        temp.GetComponent<MailItemUI>().UpdateInfo(item.usernameFrom);
        temp.GetComponent<MailItemUI>().id = item.mailId;
    }

    public void RemoveMail()
    {
        Destroy(selectItemUI.gameObject);
        itemList.Remove(selectItem);
        itemDict.Remove(selectItem.mailId);

        selectItemUI = null;
        selectItem = null;
        MailUI.Instance.HideRemoveBtn();  //隐藏删除按钮
        MailUI.Instance.UpdateText("");  //清除邮件内容
    }
}
