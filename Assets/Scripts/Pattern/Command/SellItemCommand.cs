///можно отрефакторить  с помощью разделения  отвецтвенности  и создания  отдельной команді  для обновления  UI
public class SellItemCommand : Command   
{
    Shop _shop;
    ShopUI _shopUI;
    Crop _crop;
    public SellItemCommand(Crop crop, Shop shop, ShopUI shopUI)
    {
        _crop = crop;
        _shop = shop;
        _shopUI = shopUI;
    }
    public override void Execute()
    {
        _shop.SellItem(_crop);
        _shopUI.SetProductCount(0);
        _shopUI.SetProductImage(null);
    }
}

