using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text itemAmount;
    [SerializeField] private Text itemPrice;

    public UnityEvent<ShopItemUI> ItemClicked { get; private set; } = new UnityEvent<ShopItemUI>();

    private ShopItem _shopItem;

    public ShopItem ShopItem
    {
        get { return _shopItem; }
        set 
        {
            _shopItem = value;
            icon.sprite = ShopItem.Icon;
            itemAmount.text = ShopItem.Amount.ToString();
            itemPrice.text = ShopItem.Price.ToString();
            Debug.Log($"ShopItemUI: {ShopItem} set");
        }
    }

    public void UpdateItemCount(int amount)
    {
        _shopItem.Amount += amount;
        itemAmount.text = _shopItem.Amount.ToString();
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
        Destroy(gameObject);
    }

}

