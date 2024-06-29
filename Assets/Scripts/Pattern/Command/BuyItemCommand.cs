
using UnityEngine;

public class BuyItemCommand : Command
{
    Shop _shop;
    ShopItem _item;

    public BuyItemCommand(Shop shop, ShopItem item)
    {
        _item = item;
        _shop = shop;
    }
    public override void Execute()
    {
        if (_item == null)
        {
            Debug.Log("Item to buy is null");
            return;
        }
        if (_shop.HasItem(_item))
        {
            _shop.BuyItem(_item);
        }
        else
        {
            Debug.Log($"Item {_item.Name} is not available in the shop");
        }
    }
}

