public class HarvestCommand : Command
{
    private Field _field;
    private Crop  _crop;

    public HarvestCommand(Crop crop)
    {
        _crop = crop;
        _field = crop._field;
    }

    public override void Execute()
    {
        _field.Harvest(_crop);
    }
}
