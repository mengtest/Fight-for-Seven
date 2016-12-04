using UnityEngine;
using System.Collections;

public class SignItem
{
    public int day { get; private set; }
    public bool isSign { get; private set; }

    public SignItem(int day, bool isSign)
    {
        this.day = day;
        this.isSign = isSign;
    }

    public void UpdateSign(bool isSign)
    {
        this.isSign = isSign;
    }
}
