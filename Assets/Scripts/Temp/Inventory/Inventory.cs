using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class Inventory
{
    private List<Item> _items = new(7);


    public UnityEvent<Item> ItemAdded = new();
    public UnityEvent<Item> ItemUpdated = new();
    public UnityEvent<Item> ItemRemoved = new();

    public bool InventoryFull() => _items.Count >= 7;
    public bool ContainsItem(Item item) => _items.Contains(item);

    public void AddItem(Item item)
    {
        if (item == null)
        {
            Debug.Log("Inventory: Item to add is null");
            return;
        }
        if (InventoryFull())
        {
            Debug.Log("Inventory: Full");
            return;
        }
        var existingItem = _items.Find(i => i.Name == item.Name);
        if (existingItem != null)
        {
            UpdateItemCount(existingItem, item.Amount);
        }
        else
        {
            _items.Add(item);
            Debug.Log($"Inventory: {item} added");
            ItemAdded?.Invoke(item);
        }
    }

    public void RemoveItem(Item item)
    {
        if(item == null)
        {
            Debug.Log("Inventory: Item to remove is null");
            return;
        }
        var existingItem = _items.Find(i => i.Name == item.Name);
        if (existingItem == null)
        {
            Debug.Log($"Inventory: {item} not found");
            return;
        }
        if (existingItem.Amount - item.Amount <= 0)
        {
            Debug.Log($"Inventory: {item} removed");
            _items.Remove(existingItem);
            ItemRemoved.Invoke(item);
        }
        else
        {
            UpdateItemCount(existingItem, -item.Amount);
        }
    }

    private void UpdateItemCount(Item item, int amount)
    {
        item.Amount += amount;
        Debug.Log($"Inventory: {item} updated");
        ItemUpdated.Invoke(item);
    }


}
