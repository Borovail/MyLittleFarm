using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _itemAmount;
    [SerializeField] private Text _itemPrice;

    private Item _shopItem;

    public UnityEvent<ShopItemUI> ItemClicked { get; private set; } = new ();

    public Item GetItem() => _shopItem;

    public void SetItem(Item item)
    {
        _shopItem = item;
        _icon.sprite = item.Icon;
        _itemAmount.text = item.Amount.ToString();
        _itemPrice.text = item.Price.ToString();
        Debug.Log($"ShopItemUI: {_shopItem} set");
    }


    public void UpdateItemCount(int amount)
    {
        _shopItem.Amount += amount;
        _itemAmount.text = _shopItem.Amount.ToString();
        Debug.Log($"ShopItemUI count updated with {amount}");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log($"ShopItemUI: {_shopItem} clicked");
            // Make an animation of the item being clicked
            ItemClicked?.Invoke(this);
        }
    }

    public void Destroy()
    {
        Debug.Log($"ShopItemUU: {_shopItem} destroyed");
        Destroy(gameObject);
    }

}

