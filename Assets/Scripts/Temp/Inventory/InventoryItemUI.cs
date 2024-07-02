using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _itemAmount;

    private Item _inventoryItem;
    public Item InventoryItem
    {
        get { return _inventoryItem; }
        set
        {
            _inventoryItem = value;
            _icon.sprite = _inventoryItem.Icon;
            _itemAmount.text = _inventoryItem.Amount.ToString();
            Debug.Log($"InventoryItemUI: {_inventoryItem} set");
        }
    }

    public UnityEvent<InventoryItemUI> ItemClicked { get; private set; } = new ();

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log($"InventoryItemUI: {_inventoryItem} clicked");
            // Make an animation of the item being clicked
            ItemClicked?.Invoke(this);
        }
        
    }

    public void UpdateItemCount(int amount)
    {
        _inventoryItem.Amount += amount;
        _itemAmount.text = _inventoryItem.Amount.ToString();
        Debug.Log($"InventoryItemUI count updated with {amount}");
    }

    public void Destroy()
    {
        Debug.Log($"InventoryItemUI: {_inventoryItem} destroyed");
        Destroy(gameObject);
    }
   
}
