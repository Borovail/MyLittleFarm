public class BuyItemCommand : Command
{
    Shop _shop;
    ShopUI _shopUI;
    Crop _crop;

    public BuyItemCommand(Crop crop,Shop shop,ShopUI shopUI)
    {
        _crop = crop;
        _shop = shop;
        _shopUI = shopUI;
    }
    public override void Execute()
    {
        _shop.BuyItem(_crop);
        _shopUI.SetProductCount(1);
        _shopUI.SetProductImage(_crop.Sprite);
    }
}

