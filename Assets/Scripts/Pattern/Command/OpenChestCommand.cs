public class OpenChestCommand : Command
{
    private Chest _chest;
    public OpenChestCommand(Chest chest)
    {
        _chest = chest;
    }
    public override void Execute()
    {
        _chest.Open();
    }
}

