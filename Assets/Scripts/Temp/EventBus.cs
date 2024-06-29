using UnityEngine.Events;



///Сделать словарь  ивентов  на основе типа  как ключа  и ивента  как значения
///Методы для  подписки отписки и для оповещения  и для удаления всех подписчиков
public static class EventBus
{
    public static UnityEvent<float> PlayerGoldChanged { get; } = new();
    public static UnityEvent<Item> ItemAddedToPlayer { get; } = new();
    public static UnityEvent<Item> ItemRemovedFromPlayer { get; } = new();

    public  static UnityEvent PlayerInteractedWithShop { get; } = new();
    public static UnityEvent<Item> ItemBought { get; } = new();
    public static UnityEvent<Item> ItemSold { get; } = new();

    public static void PlayerGoldChangedInvoke(float amount) => PlayerGoldChanged?.Invoke(amount);
    public static void ItemAddedToPlayerInvoke(Item item) => ItemAddedToPlayer?.Invoke(item);
    public static void ItemRemovedFromPlayerInvoke(Item item) => ItemRemovedFromPlayer?.Invoke(item);
    public static void ItemBoughtInvoke(Item item)
    {
        ItemBought?.Invoke(item);
        ItemRemovedFromPlayer?.Invoke(item);
        PlayerGoldChanged?.Invoke(item.Price);
    }
    public static void ItemSoldInvoke(Item item)
    {
        ItemSold?.Invoke(item);
        ItemAddedToPlayer?.Invoke(item);
        PlayerGoldChanged?.Invoke(-item.Price);
    }
    public static void PlayerInteractedWithShopInvoke()
    {
        PlayerInteractedWithShop?.Invoke();
    }

}
