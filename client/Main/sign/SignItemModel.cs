using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SignItemModel
{
    private static Dictionary<int, SignItem> gridItem = new Dictionary<int, SignItem>();

    public static void StoreSignItem(int day, SignItem item)
    {
        if (gridItem.ContainsKey(day))
        {
            RemoveSignItem(day);
        }
        gridItem.Add(day, item);
    }

    public static SignItem GetSignItem(int day)
    {
        if (gridItem.ContainsKey(day))
        {
            return gridItem[day];
        }
        return null;
    }

    public static void RemoveSignItem(int day)
    {
        if (gridItem.ContainsKey(day))
        {
            gridItem.Remove(day);
        }
    }
}
