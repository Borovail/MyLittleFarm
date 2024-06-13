public class PlayerInteractionVisitor : IInteractionVisitor
{
    private Inventory _inventory;
    private CommandInvoker _commandInvoker;

    public PlayerInteractionVisitor(Inventory inventory, CommandInvoker commandInvoker)
    {
        _inventory = inventory;
        _commandInvoker = commandInvoker;
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

    public void Visit(Shop shop)
    {
        shop.Interact();
    }
}
