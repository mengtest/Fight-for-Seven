using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Armor : Item
{
    public int power { get; private set; }
    public int defend { get; private set; }
    public int agility { get; private set; }

    public Armor(int id, string name, string description, int count, int buyPrice, int sellPrice, int iconIndex,
        int power, int defend, int agility)
        : base(id, name, description, count, buyPrice, sellPrice, iconIndex)
    {
        base.itemType = ItemType.Armor;
        this.power = power;
        this.defend = defend;
        this.agility = agility;
    }
}
