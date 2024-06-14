using UnityEngine;

public class ShopController : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopUI _shopUI;
    

    private Shop _shop;
    private CommandInvoker _commandInvoker;
    private Inventory _inventory;
    private float _playerGoldAmount;

    private void Start()
    {
        _shop = new Shop();
        _commandInvoker = new CommandInvoker();
        _shopUI._buyButton.onClick.AddListener(BuyItem);
        _shopUI._sellButton.onClick.AddListener(SellItem);
    }

    public void Interact(Inventory inventory,float playerGoldAmount)
    {
        _inventory = inventory;
        _playerGoldAmount = playerGoldAmount;

        if (_shopUI._shopOpen)
            _shopUI.HideUI();
        else
            _shopUI.ShowUI();
    }

    private void BuyItem()
    {
        //_commandInvoker.ExecuteCommand(new AddItemToInventoryCommand(_inventory, _shop._crop));
        //_commandInvoker.ExecuteCommand(new SellItemCommand(_shop._crop,_shop, _shopUI));
    }

    private void SellItem()
    {
        _commandInvoker.ExecuteCommand(new BuyItemCommand(_inventory._crop,_shop, _shopUI));
        _commandInvoker.ExecuteCommand(new RemoveItemFromInventoryCommand(_inventory, _inventory._crop));
    }

    public void Accept(IInteractionVisitor interactionVisitor)
    {
        interactionVisitor.Visit(this);
    }
}
