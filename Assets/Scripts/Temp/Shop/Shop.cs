using Unity.VisualScripting;
using UnityEngine;

public class Shop   //Later implement to some MVC MVP MVE pattern
{
    public Item _item; //Fix that later
    public float Gold;
    public void BuyItem(Item item)
    {
        Gold -= item.Price;
        _item = item;
        Debug.Log("Item bought " + item);
        EventBus.ItemBoughtInvoke(item);
    }

    public void SellItem()
    {
        Debug.Log("Item sold: " + _item);
        EventBus.ItemSoldInvoke(_item);
        Gold+= _item.Price;
        _item = null;
    }

}
