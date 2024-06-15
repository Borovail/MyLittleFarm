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
    }

    public void Visit(Field field)
    {
        _commandInvoker.ExecuteCommand(new PlantCommand(field,_inventory._item._crop));
    }

    public void Visit(ShopController shop)
    {
        _commandInvoker.ExecuteCommand(new ShopInteractionCommand(shop, _inventory, _player.Gold));
    }

    public void Visit(Chest chest)
    {
        _commandInvoker.ExecuteCommand(new OpenChestCommand(chest));
    }
}
