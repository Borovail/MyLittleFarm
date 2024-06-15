using System.Diagnostics;
using UnityEngine.Events;

public static class EventBus
{
    public static UnityEvent<float> AddGoldToPlayer { get; } = new();
    public static UnityEvent<Item> AddItemToPlayer { get; } = new();
    public static UnityEvent<Item> RemoveItemFromPlayer { get; } = new();

    public static UnityEvent<Item> AddItemToShop { get; } = new();
    public static UnityEvent<Item> RemoveItemFromShop { get; } = new();

    public static void AddGoldToPlayerInvoke(float amount) => AddGoldToPlayer.Invoke(amount);
    public static void AddItemToPlayerInvoke(Item item) => AddItemToPlayer.Invoke(item);
    public static void RemoveItemFromPlayerInvoke(Item item) => RemoveItemFromPlayer.Invoke(item);
    public static void AddItemToShopInvoke(Item item)
    {
        AddItemToShop.Invoke(item);
        AddItemToPlayer.Invoke(item);
    }
    public static void RemoveItemFromShopInvoke(Item item) 
    {
        RemoveItemFromShop.Invoke(item);
        RemoveItemFromPlayer.Invoke(item);
    }
}
