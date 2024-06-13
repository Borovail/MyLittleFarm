public class AddItemToInventoryCommand : Command
{
    private Inventory _inventory;
    private Crop _crop;

    public AddItemToInventoryCommand(Inventory inventory, Crop crop)
    {
        _inventory = inventory;
        _crop = crop;
    }

    public override void Execute()
    {
        _inventory.Add(_crop);
    }
}
