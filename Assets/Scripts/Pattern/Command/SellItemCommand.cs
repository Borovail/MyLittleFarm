
using UnityEngine;

public class SellItemCommand : Command   
{
    private Shop _shop;
    private Item _item => _shop._item;
    private float _playerGold;
    public SellItemCommand(Shop shop,float playerGold)
    {
        _shop = shop;
        _playerGold = playerGold;
    }
    public override void Execute()
    {
        if(_item==null)
        {
            Debug.Log("At this moment shop is empty");
            return;
        }
        
        if(_item.Price <= _playerGold)
        {
           _shop.SellItem();
        }
        else
        {
            Debug.Log($"Not enough gold for purchase.\n Needed gold: {_item.Price},player's current gold: {_playerGold}");
        }
    }
}

