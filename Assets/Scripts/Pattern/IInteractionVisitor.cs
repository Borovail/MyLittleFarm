
public interface IInteractionVisitor
{
    public void Visit(Crop crop);
    public void Visit(Field field);
    public void Visit(ShopController shop);
    public void Visit(Chest chest);

}

