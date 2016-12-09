using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FriendManager : MonoBehaviour
{
    private static FriendManager instance;
    public static FriendManager Instance { get { return instance; } }

    public GameObject friendItemPrefab;
    public Transform friendItemParent;

    private List<FriendItem> friendList = new List<FriendItem>();

    void Awake()
    {
        instance = this;

        Load();
        UpdateFriend();
    }

    //模拟从服务器获取角色信息
    void Load()
    {
        FriendItem item1 = new FriendItem("111", 6001, 5000, 11, "好友1");
        FriendItem item2 = new FriendItem("222", 6000, 5001, 22, "好友2");
        FriendItem item3 = new FriendItem("333", 6001, 5002, 33, "好友3");
        FriendItem item4 = new FriendItem("444", 6000, 5003, 44, "好友4");
        FriendItem item5 = new FriendItem("555", 6000, 5004, 55, "好友5");
        FriendItem item6 = new FriendItem("666", 6001, 5005, 66, "好友6");
        FriendItem item7 = new FriendItem("777", 6000, 5005, 77, "好友7");
        FriendItem item8 = new FriendItem("888", 6000, 5004, 88, "好友8");
        FriendItem item9 = new FriendItem("999", 6000, 5003, 99, "好友9");
        FriendItem item10 = new FriendItem("1000", 6001, 5002, 365, "好友10");

        friendList.Add(item1);
        friendList.Add(item2);
        friendList.Add(item3);
        friendList.Add(item4);
        friendList.Add(item5);
        friendList.Add(item6);
        friendList.Add(item7);
        friendList.Add(item8);
        friendList.Add(item9);
        friendList.Add(item10);
    }

    public void UpdateFriend()
    {
        foreach (var item in friendList)
        {
            GameObject goTemp = Instantiate(friendItemPrefab);
            goTemp.transform.SetParent(friendItemParent);
            goTemp.transform.localPosition = Vector3.zero;
            goTemp.transform.localScale = Vector3.one;

            goTemp.GetComponent<FriendItemUI>().UpdateHeader(item.friendHeader);
            goTemp.GetComponent<FriendItemUI>().UpdateUsername(item.friendUsername);
            goTemp.GetComponent<FriendItemUI>().SetFriendInfo(item);

            goTemp.GetComponent<Button>().onClick.AddListener(delegate { OnFriendItemBtnClick(goTemp); });  //点击监听
        }
    }

    public void OnFriendItemBtnClick(GameObject go)
    {
        FriendItem item = go.GetComponent<FriendItemUI>().ItemInfo;

        FriendUI.Instance.ShowFriendDes();
        FriendUI.Instance.UpdateFriendDes(item.friendHeader, item.friendTitle, item.friendUsername, item.logoutTime);
    }
}
