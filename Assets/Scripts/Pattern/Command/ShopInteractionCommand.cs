public class ShopInteractionCommand : Command
{
    private ShopController _shop;
    private Inventory _inventory;
    private float _playerGoldAmount; // возможно заменить на клас какой то типа  Player Stats
    public ShopInteractionCommand(ShopController shop, Inventory inventory, float playerGoldAmount)
    {
        _shop = shop;
        _inventory = inventory;
        _playerGoldAmount = playerGoldAmount;
    }
    public override void Execute()
    {
        _shop.Interact(_inventory, _playerGoldAmount);
    }
}

