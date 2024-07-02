using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _itemAmount;

    private Item _inventoryItem;

    public Item GetInventoryItem() => _inventoryItem;
    public void SetInventoryItem(Item item)
    {
        _inventoryItem = item;
        _icon.sprite = _inventoryItem.Icon;
        _itemAmount.text = _inventoryItem.Amount.ToString();
        Debug.Log($"InventoryItemUI: {_inventoryItem} set");
    }
  
    public void UpdateItem(Item item)
    {
        _inventoryItem.Amount = item.Amount;
        _itemAmount.text = _inventoryItem.Amount.ToString();
        Debug.Log($"InventoryItemUI count updated with {item.Amount}");
    }

    public void Destroy()
    {
        Debug.Log($"InventoryItemUI: {_inventoryItem} destroyed");
        Destroy(gameObject);
    }
   
}
