public class ShopCommandFactory
{
    private PlayerStats _playerStats;

    public ShopCommandFactory(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }

    public Command CreateBuyCommand(Shop shop,Item item)
    {
        return new BuyItemCommand(shop, item);
    }

    public Command CreateSellCommand(Shop shop,Item item)
    {
        return new SellItemCommand(shop, item,_playerStats.Gold);
    }

}

