using UnityEngine;

public class Shop
{
    public Item _item; //Fix that later

    public void BuyItem(Crop item)
    {
        _item._crop = item;
        _item._amount = 1;
        Debug.Log("Item bought " + item);
    }

    public void SellItem(Crop item)
    {
        _item._crop = null;
        _item._amount = 0;
        Debug.Log("Item sold: " + item);
    }

}
