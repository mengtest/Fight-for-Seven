using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ShopManager : MonoBehaviour
{
    private static ShopManager instance;
    public static ShopManager Instance { get { return instance; } }

    // 保存格子，方便加载和隐藏等操作
    public List<GameObject> gridList;
    public int petLength;
    public int dressLength;
    public int consumableLength;
    public DescriptionUI desUI;

    // 保存商品信息，需要从服务器取得数据
    private List<ShopItem> petList = new List<ShopItem>();
    private List<ShopItem> dressList = new List<ShopItem>();
    private List<ShopItem> consumableList = new List<ShopItem>();

    // 一页的格子数量
    private const int gridCount = 8;

    void Awake()
    {
        instance = this;

        Load();
        petLength = petList.Count;
        dressLength = dressList.Count;
        consumableLength = consumableList.Count;

        //注册事件
        GridUI.OnEnter += GridUIOnEnter;
        GridUI.OnExit += GridUIOnExit;
    }

    // 模拟从服务器取得商品信息
    void Load()
    {
        ShopItem pet1 = new ShopItem(1000, "路飞", "我是要成为海贼王的男人！！！", 10000, 1000, ItemType.Pet, PaymentType.Coin);
        ShopItem pet2 = new ShopItem(1001, "佐罗", "我有个野心，就是要成为世界第一的剑士！！！", 8000, 1001, ItemType.Pet, PaymentType.Coin);
        ShopItem pet3 = new ShopItem(1002, "山治", "我从小就被教导不能踢女人，所以就算会没命，我也不能踢女人。", 6000, 1002, ItemType.Pet, PaymentType.Coin);
        ShopItem pet4 = new ShopItem(1003, "艾斯", "我的人生，没有遗憾，其实我真正想要的东西并不是名声。我想知道的只是自己应不应该被生下来的答案。", 100, 1003, ItemType.Pet, PaymentType.Diamond);

        petList.Add(pet1);
        petList.Add(pet2);
        petList.Add(pet3);
        petList.Add(pet4);

        ShopItem dress1 = new ShopItem(2000, "头盔1", "这是我最爱的头盔1", 2000, 2000, ItemType.Dress, PaymentType.Coin);
        ShopItem dress2 = new ShopItem(2001, "头盔2", "这是我最爱的头盔2", 3000, 2001, ItemType.Dress, PaymentType.Coin);
        ShopItem dress3 = new ShopItem(2002, "头盔3", "这是我最爱的头盔3", 100, 2002, ItemType.Dress, PaymentType.Diamond);
        ShopItem dress4 = new ShopItem(2003, "头盔4", "这是我最爱的头盔4", 2000, 2003, ItemType.Dress, PaymentType.Coin);
        ShopItem dress5 = new ShopItem(2004, "头盔5", "这是我最爱的头盔5", 3000, 2004, ItemType.Dress, PaymentType.Coin);
        ShopItem dress6 = new ShopItem(2005, "铠甲1", "这是我最爱的铠甲1", 2000, 2005, ItemType.Dress, PaymentType.Coin);
        ShopItem dress7 = new ShopItem(2006, "铠甲2", "这是我最爱的铠甲2", 3000, 2006, ItemType.Dress, PaymentType.Coin);
        ShopItem dress8 = new ShopItem(2007, "铠甲3", "这是我最爱的铠甲3", 100, 2007, ItemType.Dress, PaymentType.Diamond);
        ShopItem dress9 = new ShopItem(2008, "铠甲4", "这是我最爱的铠甲4", 2000, 2008, ItemType.Dress, PaymentType.Coin);
        ShopItem dress10 = new ShopItem(2009, "铠甲5", "这是我最爱的铠甲5", 3000, 2009, ItemType.Dress, PaymentType.Coin);
        ShopItem dress11 = new ShopItem(2010, "跑鞋1", "这是我最爱的跑鞋1", 2000, 2010, ItemType.Dress, PaymentType.Coin);
        ShopItem dress12 = new ShopItem(2011, "跑鞋2", "这是我最爱的跑鞋2", 3000, 2011, ItemType.Dress, PaymentType.Coin);
        ShopItem dress13 = new ShopItem(2012, "跑鞋3", "这是我最爱的跑鞋3", 100, 2012, ItemType.Dress, PaymentType.Diamond);
        ShopItem dress14 = new ShopItem(2013, "跑鞋4", "这是我最爱的跑鞋4", 2000, 2013, ItemType.Dress, PaymentType.Coin);
        ShopItem dress15 = new ShopItem(2014, "跑鞋5", "这是我最爱的跑鞋5", 3000, 2014, ItemType.Dress, PaymentType.Coin);

        dressList.Add(dress1);
        dressList.Add(dress2);
        dressList.Add(dress3);
        dressList.Add(dress4);
        dressList.Add(dress5);
        dressList.Add(dress6);
        dressList.Add(dress7);
        dressList.Add(dress8);
        dressList.Add(dress9);
        dressList.Add(dress10);
        dressList.Add(dress11);
        dressList.Add(dress12);
        dressList.Add(dress13);
        dressList.Add(dress14);
        dressList.Add(dress15);

        ShopItem consumable1 = new ShopItem(3000, "护身符", "这是一个能够保你一命的好东西", 10, 3000, ItemType.Consumable, PaymentType.Diamond);
        ShopItem consumable2 = new ShopItem(3001, "挑战书", "有了它就可以向别人发起挑战", 10, 3001, ItemType.Consumable, PaymentType.Diamond);
        ShopItem consumable3 = new ShopItem(3002, "号角", "吹响它就能够增强我方战斗力", 10, 3002, ItemType.Consumable, PaymentType.Diamond);
        ShopItem consumable4 = new ShopItem(3003, "军令", "号令江山唯我独尊", 100, 3003, ItemType.Consumable, PaymentType.Diamond);
        ShopItem consumable5 = new ShopItem(3004, "幸运币", "随机获得一种属性", 5000, 3004, ItemType.Consumable, PaymentType.Coin);

        consumableList.Add(consumable1);
        consumableList.Add(consumable2);
        consumableList.Add(consumable3);
        consumableList.Add(consumable4);
        consumableList.Add(consumable5);
    }

    public void LoadPet(int from, int to)  // 加载宠物
    {
        for (int i = from; i < to; i++)
        {
            ShopItem itemTemp = petList[i];
            GameObject gridTemp = gridList[i % gridCount];
            SetState(itemTemp,gridTemp);
        }
        SetNullState(to);
    }

    public void LoadDress(int from, int to)  // 加载时装
    {
        for (int i = from; i < to; i++)
        {
            ShopItem itemTemp = dressList[i];
            GameObject gridTemp = gridList[i % gridCount];
            SetState(itemTemp, gridTemp);
        }
        SetNullState(to);
    }

    public void LoadConsumable(int from, int to)  // 加载消耗品
    {
        for (int i = from; i < to; i++)
        {
            ShopItem itemTemp = consumableList[i];
            GameObject gridTemp = gridList[i % gridCount];
            SetState(itemTemp, gridTemp);
        }
        SetNullState(to);
    }

    void SetState(ShopItem itemTemp, GameObject gridTemp)  // 更新显示，添加监听
    {
        gridTemp.SetActive(true);  // 显示格子
        gridTemp.GetComponentInChildren<ShopItemUI>().SetItem(itemTemp);
        gridTemp.GetComponentInChildren<ShopItemUI>().UpdateShopItem();  // 更新格子信息

        gridTemp.GetComponent<Button>().onClick.AddListener(delegate { OnShopItemBtnClick(gridTemp); });  //添加监听
    }

    void SetNullState(int to)  //将不足的位置置空
    {
        if (to % gridCount != 0)
        {
            for (int i = to % gridCount; i < gridCount; i++)
            {
                gridList[i].SetActive(false);
            }
        }
    }

    void OnShopItemBtnClick(GameObject gridTemp)
    {
        ShopUI.Instance.ShowBuyInfo(gridTemp.GetComponentInChildren<ShopItemUI>().item);
    }

    public void GridUIOnEnter(Transform gridTransform)  //鼠标移动到物品上面
    {
        ShopItem item = gridTransform.GetComponentInChildren<ShopItemUI>().item;
        if (item == null)
        {
            return;
        }
        else
        {
            //des更新为选择的物品
            string des = GetDesText(item);
            desUI.UpdateDes(des);

            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform,
                Input.mousePosition, null, out position);
            desUI.SetLocalPosition(position);

            desUI.ShowDes();
        }
    }

    public void GridUIOnExit()  //鼠标移出物品
    {
        desUI.UpdateDes("");
        desUI.HideDes();
    }

    private string GetDesText(ShopItem item)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=red>{0}</color>\n", item.itemName);
        switch (item.itemType)
        {
            case ItemType.Pet:
                sb.AppendFormat("类型：宠物\n");
                break;
            case ItemType.Dress:
                sb.AppendFormat("类型：时装\n");
                break;
            case ItemType.Consumable:
                sb.AppendFormat("类型：消耗品\n");
                break;
            default:
                break;
        }
        sb.AppendFormat("<size=14><color=white>购买价格：{0}</color></size>\n" +
            "<color=yellow><size=10>描述：{1}</size></color>", item.buyPrice, item.description);
        return sb.ToString();
    }
}
