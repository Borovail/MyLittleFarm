
using System.Collections.Generic;
using UnityEngine.Events;

public class Shop
{
    private List<Item> _shopItems;

    public UnityEvent<Item> ShopBoughtItem { get; private set; } = new UnityEvent<Item>();
    public UnityEvent<Item> ShopSoldItem { get; private set; } = new UnityEvent<Item>();

    public void SetItems(List<Item> shopItems)
    {
        _shopItems = shopItems;
    }

    public void BuyItem(Item shopItem)
    {
        shopItem.Amount++;
        ShopBoughtItem.Invoke(shopItem);

    }

    public void SellItem(Item shopItem)
    {
        shopItem.Amount--;
        ShopSoldItem.Invoke(shopItem);
    }

    public bool HasItem(Item shopItem) => _shopItems.Contains(shopItem);


}
