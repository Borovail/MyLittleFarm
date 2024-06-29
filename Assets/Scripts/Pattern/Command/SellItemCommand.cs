
using UnityEngine;

public class SellItemCommand : Command   
{
    private ShopItem _shopItem;
    private Shop _shop;
    private float _playerGold;
    public SellItemCommand(Shop shop,ShopItem shopItem,float playerGold)
    {
        _shop = shop;
        _shopItem = shopItem;
        _playerGold = playerGold;
    }
    public override void Execute()
    {
        if(_shopItem == null)
        {
            Debug.Log("Item to sell is null");
            return;
        }
        if(_shopItem.Amount == 0)
        {
            Debug.Log($"{_shopItem.Name} is currently out of stock");;
            return;
        }
        if(_shopItem.Price <= _playerGold)
        {
           _shop.SellItem(_shopItem);
        }
        else
        {
            Debug.Log($"Not enough gold for purchase.\n Needed gold: {_shopItem.Price},player's current gold: {_playerGold}");
        }
    }
}

