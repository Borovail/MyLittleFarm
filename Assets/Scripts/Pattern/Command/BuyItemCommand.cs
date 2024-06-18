
using UnityEngine;

public class BuyItemCommand : Command
{
    Shop _shop;
    Item _item;

    public BuyItemCommand(Shop shop,Item item)
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

        if (_shop.Gold >= _item.Price)
        {
            _shop.BuyItem(_item);
        }
        else
        {
            Debug.Log($"Shop does not have enough gold to buy an item.\nShop's balance: {_shop.Gold}, needed gold: {_item.Price}");
        }
    }
}

