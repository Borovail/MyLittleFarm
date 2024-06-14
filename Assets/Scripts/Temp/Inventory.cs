using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Crop _crop;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Add(Crop crop)
    {
        _crop = crop;
        _image.sprite = crop.Sprite;
        Debug.Log($"Added crop {crop.Name} to inventory");
    }

    public void Remove(Crop crop)
    {
        Debug.Log($"Removed crop {crop.Name} from inventory");
        _crop = null;
        _image.sprite = null;
    }
}
