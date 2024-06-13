public class CloseShopUICommand : Command
{
    private ShopUI _shopUI;
    public CloseShopUICommand(ShopUI shopUI)
    {
        _shopUI = shopUI;
    }
    public override void Execute()
    {
        _shopUI.HideUI();
    }
}

