
using UnityEngine;

///можно отрефакторить  с помощью разделения  отвецтвенности  и создания  отдельной команді  для обновления  UI
public class SellItemCommand : Command   
{
    Shop _shop;
    Item _item;
    float _playerGold;
    public SellItemCommand(Item item, Shop shop,float playerGold)
    {
        _item = item;
        _shop = shop;
        _playerGold = playerGold;
    }
    public override void Execute()
    {
        if(_item._crop.Price <= _playerGold)
        {
           _shop.SellItem(_item);
        }
        else
        {
            Debug.Log($"Not enough gold for purchase.\n Needed gold: {_item._crop.Price}, current gold: {_playerGold}");
        }
    }
}

