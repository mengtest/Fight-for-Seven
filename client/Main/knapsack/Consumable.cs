using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Consumable : Item
{
    public int backHp;
    public int backMp;

    public Consumable(int id, string name, string description, int count, int buyPrice, int sellPrice, int iconIndex,
        int backHp, int backMp)
        : base(id, name, description, count, buyPrice, sellPrice, iconIndex)
    {
        base.itemType = ItemType.Consumable;
        this.backMp = backHp;
        this.backHp = backMp;
    }
}
