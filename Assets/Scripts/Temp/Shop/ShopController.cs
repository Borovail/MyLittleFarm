using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour, IInteractable
{
    public ShopUI ShopUI;

    private Shop _shop;
    private ShopCommandFactory _shopCommandFactory;
    private CommandInvoker _commandInvoker;

    private void Awake()
    {
        _shop = new Shop();
    }

    private void Start()
    {
        List<Item> shopItems = new List<Item>
        {
            new Item("Item1", 10, 4,null),
            new Item("Item2", 20, 2, null),
            new Item("Item3", 30, 5, null),
            new Item("Item4", 40, 1,null),
            new Item("Item5", 50, 6, null),
        };

        _shop.SetItems(shopItems);
        ShopUI.SetItems(shopItems);
    }

    public void Initialize(ShopCommandFactory shopCommandFactory, CommandInvoker commandInvoker)
    {
        _shopCommandFactory = shopCommandFactory;
        _commandInvoker = commandInvoker;
    }

    private void OnEnable()
    {
        ShopUI.BuyButtonClicked.AddListener(_shop.SellItem);
        ShopUI.SellButtonClicked.AddListener(_shop.BuyItem);
        _shop.ShopBoughtItem.AddListener(ShopUI.UpdateUI);
        _shop.ShopSoldItem.AddListener(ShopUI.UpdateUI);
    }

    private void OnDisable()
    {
        ShopUI.BuyButtonClicked.RemoveListener(_shop.SellItem);
        ShopUI.SellButtonClicked.RemoveListener(_shop.BuyItem);
        _shop.ShopBoughtItem.RemoveListener(ShopUI.UpdateUI);
        _shop.ShopSoldItem.RemoveListener(ShopUI.UpdateUI);
    }
    public void Accept(IInteractionVisitor interactionVisitor)
    {
        interactionVisitor.Visit(this);
    }
}
