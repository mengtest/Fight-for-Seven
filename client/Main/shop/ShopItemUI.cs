using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopItemUI : MonoBehaviour
{
    public Image iconImage;
    public Image paymentImage;
    public Text priceText;

    public ShopItem item;

    public void SetItem(ShopItem item)
    {
        this.item = item;
    }

    public void UpdateShopItem()
    {
        if (item != null)
        {
            iconImage.sprite = Resources.Load("images/" + item.iconIndex, new Sprite().GetType()) as Sprite;

            switch (item.paymentType)
            {
                case PaymentType.Coin:
                    paymentImage.sprite = Resources.Load("images/6002", new Sprite().GetType()) as Sprite;
                    break;
                case PaymentType.Diamond:
                    paymentImage.sprite = Resources.Load("images/6003", new Sprite().GetType()) as Sprite;
                    break;
                default:
                    break;
            }

            priceText.text = item.buyPrice.ToString();
        }
    }
}
