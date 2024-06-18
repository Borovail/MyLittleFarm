using UnityEngine;

public class ShopController : MonoBehaviour, IInteractable
{
    public ShopUI ShopUI;


    private Shop _shop;
    private CommandInvoker _commandInvoker;

    [SerializeField] private Crop _initialCrop;
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;


    private void Start()
    {
        _shop = new();
        _shop._item = new Item(_initialCrop,1);
        EventBus.ItemBought.Invoke(_shop._item);
        _commandInvoker = new CommandInvoker();
    }

    private void OnEnable()
    {
        EventBus.BuyButtonClicked.AddListener(() =>{
            _commandInvoker.ExecuteCommand(new SellItemCommand(_shop,_player.Gold));
        });
        EventBus.SellButtonClicked.AddListener(() =>{
            _commandInvoker.ExecuteCommand(new BuyItemCommand(_shop, _inventory._item));
        });
    }

    private void OnDisable()
    {
        EventBus.SellButtonClicked?.RemoveAllListeners();
        EventBus.BuyButtonClicked?.RemoveAllListeners();
    }

    public void Accept(IInteractionVisitor interactionVisitor)
    {
        interactionVisitor.Visit(this);
    }
}
