using UnityEngine;

public class ShopController : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopUI _shopUI;
    

    private Shop _shop;
    private CommandInvoker _commandInvoker;
    private Inventory _inventory;
    private float _playerGoldAmount;
    private float _shopGoldAmount;

    private void Start()
    {
        _shop = new Shop();
        _commandInvoker = new CommandInvoker();
        _shopGoldAmount = 0;
    }

    private void OnEnable()
    {
        _shopUI._buyButton.onClick.AddListener(BuyItem);
        _shopUI._sellButton.onClick.AddListener(SellItem);
    }

    private void OnDisable()
    {
        _shopUI._buyButton.onClick.RemoveListener(BuyItem);
        _shopUI._sellButton.onClick.RemoveListener(SellItem);
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
        _commandInvoker.ExecuteCommand(new SellItemCommand(_shop._item, _shop, _playerGoldAmount));
    }

    private void SellItem()
    {
        _commandInvoker.ExecuteCommand(new BuyItemCommand(_inventory._item, _shop, _shopGoldAmount));
    }

    public void Accept(IInteractionVisitor interactionVisitor)
    {
        interactionVisitor.Visit(this);
    }
}
