
using UnityEngine;

public class BuyItemCommand : Command
{
    Shop _shop;
    Item _item;
    float _shopGoldAmount;

    public BuyItemCommand(Item item, Shop shop, float shopGoldAmount)
    {
        _item = item;
        _shop = shop;
        _shopGoldAmount = shopGoldAmount;
    }
    public override void Execute()
    {
        if (_shopGoldAmount >= _item._crop.Price)
        {
            _shop.BuyItem(_item);
        }
        else
        {
            Debug.Log($"Shop does not have enough gold to buy an item.\nShop's balance: {_shopGoldAmount}, needed gold: _item._crop.Price");
        }
    }
}

