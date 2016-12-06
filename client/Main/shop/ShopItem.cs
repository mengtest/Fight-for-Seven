using UnityEngine;
using System.Collections;

public enum PaymentType
{
    Coin,
    Diamond
}

public class ShopItem
{
    public int id;
    public string itemName;
    public string description;
    public int buyPrice;
    public int iconIndex;
    public ItemType itemType;
    public PaymentType paymentType;

    public ShopItem(int id, string itemName, string description, int buyPrice, int iconIndex, ItemType itemType, PaymentType paymentType)
    {
        this.id = id;
        this.itemName = itemName;
        this.description = description;
        this.buyPrice = buyPrice;
        this.iconIndex = iconIndex;
        this.itemType = itemType;
        this.paymentType = paymentType;
    }
}