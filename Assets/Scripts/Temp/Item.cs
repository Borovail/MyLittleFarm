public class Item
{
    public Crop _crop;
    public int _amount;
    public float Price => _crop.Price;
    public Item(Crop crop, int amount)
    {
        _crop = crop;
        _amount = amount;
    }
    
}

