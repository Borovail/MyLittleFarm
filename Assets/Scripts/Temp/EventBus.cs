using UnityEngine.Events;



///Сделать словарь  ивентов  на основе типа  как ключа  и ивента  как значения
///Методы для  подписки отписки и для оповещения  и для удаления всех подписчиков
public class EventBus
{
    public  UnityEvent<float> PlayerGoldChanged { get; } = new();
    public  UnityEvent<Item> ItemAddedToPlayer { get; } = new();
    public  UnityEvent<Item> ItemRemovedFromPlayer { get; } = new();

    public   UnityEvent PlayerInteractedWithShop { get; } = new();
    public  UnityEvent<Item> ItemBought { get; } = new();
    public  UnityEvent<Item> ItemSold { get; } = new();

    public  void PlayerGoldChangedInvoke(float amount) => PlayerGoldChanged?.Invoke(amount);
    public  void ItemAddedToPlayerInvoke(Item item) => ItemAddedToPlayer?.Invoke(item);
    public  void ItemRemovedFromPlayerInvoke(Item item) => ItemRemovedFromPlayer?.Invoke(item);
    public  void ItemBoughtInvoke(Item item)
    {
        ItemBought?.Invoke(item);
        ItemRemovedFromPlayer?.Invoke(item);
        PlayerGoldChanged?.Invoke(item.Price);
    }
    public  void ItemSoldInvoke(Item item)
    {
        ItemSold?.Invoke(item);
        ItemAddedToPlayer?.Invoke(item);
        PlayerGoldChanged?.Invoke(-item.Price);
    }
    public  void PlayerInteractedWithShopInvoke()
    {
        PlayerInteractedWithShop?.Invoke();
    }

}
