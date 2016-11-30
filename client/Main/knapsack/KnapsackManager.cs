using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class KnapsackManager : MonoBehaviour
{
    private static KnapsackManager instance;
    public static KnapsackManager Instance { get { return instance; } }
    public GridPanelUI gridPanelUI;
    public DescriptionUI desUI;
    public DragItemUI dragUI;

    private Dictionary<int, Item> itemDict = new Dictionary<int, Item>();
    private string gridTag = "Grid";
    private bool isDragNull = false;

    void Awake()
    {
        instance = this;
        Load();

        //注册事件
        GridUI.OnEnter += GridUIOnEnter;
        GridUI.OnExit += GridUIOnExit;
        GridUI.OnLeftBeginDrag += GridUIOnLeftBeginDrag;
        GridUI.OnLeftDrag += GridUIOnLeftDrag;
        GridUI.OnLeftEndDrag += GridUIOnLeftEndDrag;
    }

    //模拟取数据
    private void Load()
    {
        Weapon w = new Weapon(1000, "武器", "一把武器", 1, 20, 10, 1000, 100);

        Armor a1 = new Armor(2000, "头盔", "极好的头盔", 1, 20, 10, 2000, 100, 100, 100);
        Armor a2 = new Armor(2001, "铠甲", "极好的铠甲", 1, 20, 10, 2001, 100, 100, 100);
        Armor a3 = new Armor(2002, "鞋子", "极好的鞋子", 1, 20, 10, 2002, 100, 100, 100);

        Consumable c = new Consumable(3000, "玉佩", "极好的玉佩", 2, 20, 10, 3000, 100, 100);

        itemDict.Add(w.id, w);
        itemDict.Add(a1.id, a1);
        itemDict.Add(a2.id, a2);
        itemDict.Add(a3.id, a3);
        itemDict.Add(c.id, c);
    }

    public void StoreItem(int id)
    {
        if (itemDict.ContainsKey(id))
        {
            Transform emptyGrid = gridPanelUI.GetEmptyGrid();
            if (emptyGrid == null)
            {
                Debug.Log("背包满啦！！！");
                return;
            }
            Item temp = itemDict[id];

            //在空格子上创建新物品
            CreateNewItem(emptyGrid, temp);
        }
    }

    public void CreateNewItem(Transform parent, Item item)
    {
        GameObject goPrefab = Resources.Load<GameObject>("prefabs/item");
        goPrefab.GetComponent<ItemUI>().UpdateIcon(item.iconIndex);
        goPrefab.GetComponent<ItemUI>().UpdateCount(item.count);
        GameObject goItem = GameObject.Instantiate(goPrefab);
        goItem.transform.SetParent(parent);
        goItem.transform.localPosition = Vector3.zero;
        goItem.transform.localScale = Vector3.one;

        //存储数据
        ItemModel.StoreItem(parent.name, item);
    }

    public void GridUIOnEnter(Transform gridTransform)  //鼠标移动到物品上面
    {
        Item item = ItemModel.GetItem(gridTransform.name);
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

    public void GridUIOnLeftBeginDrag(Transform gridTransform)  //开始拖动
    {
        if (gridTransform.childCount == 0)  //格子上没有物品
        {
            isDragNull = true;  //禁止拖动空格子
            return;
        }
        else
        {
            isDragNull = false;

            //drag item更新为选择的物品
            Item item = ItemModel.GetItem(gridTransform.name);
            if (item != null)
            {
                dragUI.UpdateIcon(item.iconIndex);
                dragUI.UpdateCount(item.count);

                //将选择的物品从格子上销毁
                Destroy(gridTransform.GetChild(0).gameObject);

                //显示拖动物品
                Vector2 position;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform,
                    Input.mousePosition, null, out position);
                dragUI.SetLocalPosition(position);

                dragUI.ShowItem();
            }
        }
    }

    public void GridUIOnLeftDrag(Transform gridTransform)  //拖动过程
    {
        Item item = ItemModel.GetItem(gridTransform.name);
        if (item != null)
        {
            dragUI.UpdateIcon(item.iconIndex);
            dragUI.UpdateCount(item.count);

            //显示拖动物品
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform,
                Input.mousePosition, null, out position);
            dragUI.SetLocalPosition(position);

            dragUI.ShowItem();
        }
    }

    public void GridUIOnLeftEndDrag(Transform prevTransform, Transform enterTransform)  //结束拖动
    {
        if (isDragNull)
        {
            return;
        }

        if (enterTransform == null)  //丢弃物品
        {
            //将选择的物品从格子中移出
            ItemModel.RemoveItem(prevTransform.name);
            Debug.Log("丢弃...");
        }
        else if (enterTransform.tag == gridTag)  //拖到另一个格子里
        {
            if (enterTransform.childCount == 0)  //格子上没有物品，直接放置到新格子上
            {
                Item item = ItemModel.GetItem(prevTransform.name);  //先保存好之前的物品

                /***
                一定要先移出再创建，如果先创建再移除，当prevTransform等于enterTransform时会产生错误
                ***/

                //将选择的物品从格子中移出
                ItemModel.RemoveItem(prevTransform.name);

                CreateNewItem(enterTransform, item);
            }
            else  //格子上有物品，交换两个物品
            {
                Item prevGridItem = ItemModel.GetItem(prevTransform.name);
                Item enterGridItem = ItemModel.GetItem(enterTransform.name);
                //删除新格子上的物品
                //Destroy(prevTransform.GetChild(0).gameObject);
                Destroy(enterTransform.GetChild(0).gameObject);
                //交换两个物品的数据
                CreateNewItem(enterTransform, prevGridItem);
                CreateNewItem(prevTransform, enterGridItem);
            }
        }
        else  //拖到其他UI格子里，不允许
        {
            Item item = ItemModel.GetItem(prevTransform.name);
            CreateNewItem(prevTransform, item);
        }

        dragUI.UpdateIcon(0);
        dragUI.UpdateCount(0);
        dragUI.HideItem();
    }

    private string GetDesText(Item item)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=red>{0}</color>\n", item.name);
        switch (item.itemType)
        {
            case ItemType.Weapon:
                Weapon w = item as Weapon;
                sb.AppendFormat("攻击：{0}\n", w.damage);
                break;
            case ItemType.Armor:
                Armor a = item as Armor;
                sb.AppendFormat("力量：{0}\n防御：{1}\n敏捷：{2}\n", a.power, a.defend, a.agility);
                break;
            case ItemType.Consumable:
                Consumable c = item as Consumable;
                sb.AppendFormat("HP：{0}\nMP：{1}\n", c.backHp, c.backMp);
                break;
            default:
                break;
        }
        sb.AppendFormat("<size=14><color=white>购买价格：{0}\n出售价格：{1}</color></size>\n" +
            "<color=yellow><size=10>描述：{2}</size></color>", item.buyPrice, item.sellPrice, item.description);
        return sb.ToString();
    }
}
