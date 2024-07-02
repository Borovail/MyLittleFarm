using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlot _slotPrefab;
    [SerializeField] private InventoryItemUI _inventoryItemUIPrefab;

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
        var inventorySlot = _inventorySlots.Find(s => s.GetInventoryItemUI() == null);
        var inventoryItemUI = Instantiate(_inventoryItemUIPrefab, inventorySlot.transform);
        inventoryItemUI.SetInventoryItem(item);
        inventorySlot.SetInventoryItemUI(inventoryItemUI);
        _inventoryItemUIs.Add(inventoryItemUI);
        Debug.Log($"UI item added: {item}");
    }
    public void OnItemUpdated(Item item)
    {
        _inventoryItemUIs.Find(i => i.GetInventoryItem().Name == item.Name).UpdateItem(item);
        Debug.Log($"UI item updated: {item}");
    }
    public void OnItemRemoved(Item item)
    {
        var inventoryItemUI = _inventoryItemUIs.Find(i => i.GetInventoryItem().Name == item.Name);
        _inventoryItemUIs.Remove(inventoryItemUI);
        inventoryItemUI.Destroy();
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
        Debug.Log("InventoryUI slots set");
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

