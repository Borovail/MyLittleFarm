
using System.Collections.Generic;
using UnityEngine;
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

    public void BuyItem(ShopTransaction shopTransaction)
    {
        if (shopTransaction.ItemName == null)
        {
            Debug.Log("Shop: Item to buy is null");
            return;
        }
        var item = _shopItems.Find(i => i.Name == shopTransaction.ItemName);
        if (item == null)
        {
            Debug.Log($"Shop: {item} not found in the shop list");
            return;
        }
        else
        {
            item.Amount += shopTransaction.Amount;
            Debug.Log($"Shop: {item} amount increased by {shopTransaction.Amount}");
            ShopBoughtItem.Invoke(item);
        }
    }

    public void SellItem(ShopTransaction shopTransaction)
    {
        if (shopTransaction.ItemName == null)
        {
            Debug.Log("Shop: Item to sell is null");
            return;
        }
        var item = _shopItems.Find(i => i.Name == shopTransaction.ItemName);
        if (item == null)
        {
            Debug.Log($"Shop: {item} not found in the shop list");
            return;
        }
        else
        {
            item.Amount -= shopTransaction.Amount;
            Debug.Log($"Shop: {item} amount decreased by {shopTransaction.Amount}");
            ShopSoldItem.Invoke(item);
        }

    }

    public bool HasItem(Item shopItem) => _shopItems.Contains(shopItem);


}
