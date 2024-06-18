public class PlayerShopInteractionCommand : Command
{
    private ShopUI _shopUI;
    public PlayerShopInteractionCommand(ShopUI shopUI)
    {
        _shopUI = shopUI;
    }
    public override void Execute()
    {
        if(_shopUI.gameObject.activeSelf)
        {
            _shopUI.HideUI();
        }
        else
        {
            _shopUI.ShowUI();
        }
    }
}

