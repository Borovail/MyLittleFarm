public class ShopCommandFactory
{
    private PlayerStats _playerStats;
    private Inventory _inventory;

    public ShopCommandFactory(PlayerStats playerStats, Inventory inventory)
    {
        _playerStats = playerStats;
        _inventory = inventory;
    }

    public Command CreateBuyCommand(Shop shop)
    {
        return new BuyItemCommand(shop, _inventory.CurrentItem);
    }

    public Command CreateSellCommand(Shop shop,Item item)
    {
        return new SellItemCommand(shop, item,_playerStats.Gold);
    }

}

