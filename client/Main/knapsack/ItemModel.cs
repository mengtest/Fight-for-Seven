using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ItemModel
{
    private static Dictionary<string, Item> gridItem = new Dictionary<string, Item>();

    public static void StoreItem(string name, Item item)
    {
        if (gridItem.ContainsKey(name))
        {
            RemoveItem(name);
        }
        gridItem.Add(name, item);
    }

    public static Item GetItem(string name)
    {
        if (gridItem.ContainsKey(name))
        {
            return gridItem[name];
        }
        return null;
    }

    public static void RemoveItem(string name)
    {
        if (gridItem.ContainsKey(name))
        {
            gridItem.Remove(name);
        }
    }
}
