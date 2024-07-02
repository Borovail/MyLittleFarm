using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private int _slotsCount = 7;
    [SerializeField] private InventoryUI _inventoryUI;

    private Inventory _inventory;

    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void Start()
    {
        _inventoryUI.SetSlots(_slotsCount);

        _inventory.ItemAdded.AddListener(_inventoryUI.OnItemAdded);
        _inventory.ItemUpdated.AddListener(_inventoryUI.OnItemUpdated);
        _inventory.ItemRemoved.AddListener(_inventoryUI.OnItemRemoved);
    }

    private void OnDisable()
    {
        _inventory.ItemAdded.RemoveListener(_inventoryUI.OnItemAdded);
        _inventory.ItemUpdated.RemoveListener(_inventoryUI.OnItemUpdated);
        _inventory.ItemRemoved.RemoveListener(_inventoryUI.OnItemRemoved);
    }
}

