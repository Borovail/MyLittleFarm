using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlot _slotPrefab;

    private List<InventoryItemUI> _inventoryItemUIs = new List<InventoryItemUI>();
    private List<InventorySlot> _inventorySlots = new List<InventorySlot>();
    private InventoryItemUI _currentInventoryItemUI;
    private InventorySlot _currentInventorySlot;

    private GridLayoutGroup _inventoryGrid;

    private void Awake()
    {
        _inventoryGrid = GetComponent<GridLayoutGroup>();
    }

    public void OnItemAdded(Item item)
    {
        Debug.Log($"Shop UI updated with new item: {item}");
    }
    public void OnItemUpdated(Item item)
    {
        Debug.Log($"UI item updated with new item: {item}");
    }
    public void OnItemRemoved(Item item)
    {
        Debug.Log($"UI item removed: {item}");
    }


    public void SetSlots(int SlotsCount)
    {
        for (int i = 0; i < SlotsCount; i++)
        {
            var inventorySlot = Instantiate(_slotPrefab, _inventoryGrid.transform);
            _inventorySlots.Add(inventorySlot);
            inventorySlot.SlotSelected.AddListener(OnSlotSelected);
        }
    }


    private void OnSlotSelected(InventorySlot inventorySlot)
    {
        Debug.Log("Slot selected");
        _currentInventorySlot = inventorySlot;
    }

    private void OnDisable()
    {
        foreach (var inventorySlot in _inventorySlots)
        {
            inventorySlot.SlotSelected.RemoveListener(OnSlotSelected);
        }
    }
}

