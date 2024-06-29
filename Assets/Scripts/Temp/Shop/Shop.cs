
using System.Collections.Generic;
using UnityEngine.Events;

public class Shop
{
    private List<ShopItem> _shopItems = new List<ShopItem>();

    public UnityEvent<ShopItem> ShopBoughtItem { get; private set; } = new UnityEvent<ShopItem>();
    public UnityEvent<ShopItem> ShopSoldItem { get; private set; } = new UnityEvent<ShopItem>();

    public void BuyItem(ShopItem shopItem)
    {
        shopItem.Amount++;
        ShopBoughtItem.Invoke(shopItem);

    }

    public void SellItem(ShopItem shopItem)
    {
        shopItem.Amount--;
        ShopSoldItem.Invoke(shopItem);
    }

    public bool HasItem(ShopItem shopItem) => _shopItems.Contains(shopItem);


}
