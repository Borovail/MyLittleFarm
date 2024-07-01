using UnityEngine;

public class ShopController : MonoBehaviour, IInteractable
{
    public ShopUI ShopUI;

    private Shop _shop;
    private ShopCommandFactory _shopCommandFactory;
    private CommandInvoker _commandInvoker;

    private void Start()
    {
        _shop = new Shop();
    }

    public void Initialize(ShopCommandFactory shopCommandFactory, CommandInvoker commandInvoker)
    {
        _shopCommandFactory = shopCommandFactory;
        _commandInvoker = commandInvoker;
    }

    private void OnEnable()
    {
        ShopUI.BuyButtonClicked.AddListener(SellItem);
        ShopUI.SellButtonClicked.AddListener(BuyItem);
        _shop.ShopBoughtItem.AddListener(ShopUI.UpdateUI);
        _shop.ShopSoldItem.AddListener(ShopUI.UpdateUI);
    }

    private void OnDisable()
    {
        ShopUI.BuyButtonClicked.RemoveListener(SellItem);
        ShopUI.SellButtonClicked.RemoveListener(BuyItem);
        _shop.ShopBoughtItem.RemoveListener(ShopUI.UpdateUI);
        _shop.ShopSoldItem.RemoveListener(ShopUI.UpdateUI);
    }

    private void BuyItem()
    {
        var buyCommand = _shopCommandFactory.CreateBuyCommand(_shop); 
        _commandInvoker.ExecuteCommand(buyCommand);
    }

    private void SellItem(Item shopItem)
    {
        var sellCommand = _shopCommandFactory.CreateSellCommand(_shop, shopItem);
        _commandInvoker.ExecuteCommand(sellCommand);
    }

    public void Accept(IInteractionVisitor interactionVisitor)
    {
        interactionVisitor.Visit(this);
    }
}
