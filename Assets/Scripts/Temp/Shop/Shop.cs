using UnityEngine;

public class Shop
{
    public Item _item; //Fix that later

    public void BuyItem(Item item)
    {
        _item = item;
        EventBus.RemoveItemFromShopInvoke(item);
        Debug.Log("Item bought " + item);
    }

    public void SellItem(Item item)
    {
        _item = null;
        EventBus.AddItemToShopInvoke(item);
        Debug.Log("Item sold: " + item);
    }

}
