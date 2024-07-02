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


    public Item ShopItem
    {
        get { return _shopItem; }
        set 
        {
            _shopItem = value;
            _icon.sprite = ShopItem.Icon;
            _itemAmount.text = ShopItem.Amount.ToString();
            _itemPrice.text = ShopItem.Price.ToString();
            Debug.Log($"ShopItemUI: {ShopItem} set");
        }
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

