public class OpenShopUICommand : Command
{
    private ShopUI _shopUI;
    public OpenShopUICommand(ShopUI shopUI)
    {
        _shopUI = shopUI;
    }
    public override void Execute()
    {
        _shopUI.ShowUI();
    }
}

