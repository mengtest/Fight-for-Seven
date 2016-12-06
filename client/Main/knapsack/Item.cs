using UnityEngine;
using System.Collections;

public enum ItemType
{
    Weapon,
    Armor,
    Pet,
    Dress,
    Consumable,
}

public class Item
{
    public int id { get; private set; }
    public string name { get; private set; }
    public string description { get; private set; }
    public int count { get; private set; }
    public int buyPrice { get; private set; }
    public int sellPrice { get; private set; }
    public int iconIndex { get; private set; }
    public ItemType itemType { get; protected set; }

    public Item(int id,string name,string description, int count, int buyPrice,int sellPrice,int iconIndex)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.count = count;
        this.buyPrice = buyPrice;
        this.sellPrice = sellPrice;
        this.iconIndex = iconIndex;
    }
}
