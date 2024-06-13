public class RemoveItemFromInventoryCommand : Command
{
    private Inventory _inventory;
    private Crop _crop;

    public RemoveItemFromInventoryCommand(Inventory inventory, Crop crop)
    {
        _inventory = inventory;
        _crop = crop;
    }

    public override void Execute()
    {
        _inventory.Remove(_crop);
    }
}
