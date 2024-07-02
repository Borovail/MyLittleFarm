using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    private InventoryItemUI _inventoryItemUI;

    public UnityEvent<InventorySlot> SlotSelected = new();

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Slot clicked");
        // Add an animation to the slot clicked
        SlotSelected.Invoke(this);
    }

    public void SetInventoryItemUI(InventoryItemUI inventoryItemUI)
    {
        _inventoryItemUI = inventoryItemUI;
        Instantiate(inventoryItemUI, transform);
    }

    public InventoryItemUI GetInventoryItemUI()
    {
        return _inventoryItemUI;
    }
}

