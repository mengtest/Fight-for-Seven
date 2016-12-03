using UnityEngine;
using System.Collections;

public class SumSignItem
{
    public int sumDay { get; private set; }
    public int spriteIndex { get; private set; }
    public bool isGet { get; private set; }

    public SumSignItem(int sumDay, int spriteIndex, bool isGet)
    {
        this.sumDay = sumDay;
        this.spriteIndex = spriteIndex;
        this.isGet = isGet;
    }
}
