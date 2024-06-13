public class PlantCommand : Command
{
    private Crop _crop;
    private Field _field;

    public PlantCommand(Field field,Crop crop)
    {
        _field = field;
        _crop = crop;
    }

    public override void Execute()
    {
        _field.Plant(_crop);
    }

}

