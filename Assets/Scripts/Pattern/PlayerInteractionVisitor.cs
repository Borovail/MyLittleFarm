public class PlayerInteractionVisitor : IInteractionVisitor
{
    private Player _player;
    private Inventory _inventory;
    private CommandInvoker _commandInvoker;

    public PlayerInteractionVisitor(Inventory inventory, CommandInvoker commandInvoker, Player player)
    {
        _inventory = inventory;
        _commandInvoker = commandInvoker;
        _player = player;
    }

    public void Visit(Crop crop)
    {
        _commandInvoker.ExecuteCommand(new HarvestCommand(crop));
        _commandInvoker.ExecuteCommand(new AddItemToInventoryCommand(_inventory, crop));
    }

    public void Visit(Field field)
    {
        _commandInvoker.ExecuteCommand(new PlantCommand(field,_inventory._crop));
        _commandInvoker.ExecuteCommand(new RemoveItemFromInventoryCommand(_inventory,_inventory._crop));
    }

    public void Visit(ShopController shop)
    {
        shop.Interact(_inventory,_player.Gold);
    }

    public void Visit(Chest chest)
    {
        _commandInvoker.ExecuteCommand(new AddGoldToPlayerCommand(_player, chest.Gold));
        _commandInvoker.ExecuteCommand(new OpenChestCommand(chest));
    }
}
