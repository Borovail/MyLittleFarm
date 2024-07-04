using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _itemAmount;
    [SerializeField] private Text _itemPrice;

    private Item _item;
    public UnityEvent<ShopItemUI> ItemClicked { get; private set; } = new ();

    public Item GetItem() => _item;

    public void SetItem(Item item)
    {
        _item = item;
        _icon.sprite = item.Icon;
        _itemAmount.text = item.Amount.ToString();
        _itemPrice.text = item.Price.ToString();
        Debug.Log($"ShopItemUI: {_item} set");
    }

    public void UpdateItem(Item item)
    {
        _item = item;
        _itemAmount.text = item.Amount.ToString();
        Debug.Log($"ShopItemUI: {_item} updated");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log($"ShopItemUI: {_item} clicked");
            // Make an animation of the item being clicked
            ItemClicked?.Invoke(this);
        }
    }

    public void Destroy()
    {
        Debug.Log($"ShopItemUU: {_item.Name} destroyed");
        Destroy(gameObject);
    }

}

