using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item _item;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        //EventBus.ItemAddedToPlayer.AddListener(AddItem);
        //EventBus.ItemRemovedFromPlayer.AddListener(RemoveItem);
    }

    private void OnDisable()
    {
        //EventBus.ItemAddedToPlayer.RemoveListener(AddItem);
        //EventBus.ItemRemovedFromPlayer.RemoveListener(RemoveItem);
    }
    private void AddItem(Item item)
    {
        _item  = item;
        //_image.sprite = item._crop.Sprite;
        //Debug.Log($"Added crop {item._crop.Name} to inventory");
    }

    private void RemoveItem(Item item)
    {
        //Debug.Log($"Removed crop {item._crop.Name} from inventory");
        _item = null;
        _image.sprite = null;
    }
}
