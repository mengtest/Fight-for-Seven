using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Weapon : Item
{
    public int damage { get; private set; }

    public Weapon(int id, string name, string description, int count, int buyPrice, int sellPrice, int iconIndex, int damage)
        : base(id, name, description, count, buyPrice, sellPrice, iconIndex)
    {
        base.itemType = ItemType.Weapon;
        this.damage = damage;
    }
}
