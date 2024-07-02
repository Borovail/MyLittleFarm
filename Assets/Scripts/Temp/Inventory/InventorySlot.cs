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
        inventoryItemUI.transform.SetParent(transform);
        inventoryItemUI.transform.localPosition = Vector3.zero;
    }

    public InventoryItemUI GetInventoryItemUI()
    {
        return _inventoryItemUI;
    }
}

