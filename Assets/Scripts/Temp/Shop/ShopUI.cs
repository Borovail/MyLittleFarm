using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopItemUI _shopItemUIPrefab;

    [SerializeField] private Text _totalAmount;
    [SerializeField] private Text _totalPrice;
    [SerializeField] private Slider _totalAmountSlider;

    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _sellButton;

    [SerializeField] private Transform _itemsGrid;



    private List<ShopItemUI> _shopItemUIs = new List<ShopItemUI>();
    private ShopTransaction _currentShopTransaction = new ShopTransaction();
    private Item _currentItem;

    public UnityEvent<ShopTransaction> BuyButtonClicked { get; private set; } = new();
    public UnityEvent<ShopTransaction> SellButtonClicked { get; private set; } = new();

    public void SetItems(List<Item> items)
    {
        foreach (var item in items)
        {
            var shopItemUI = Instantiate(_shopItemUIPrefab, _itemsGrid);
            shopItemUI.SetItem(item);
            _shopItemUIs.Add(shopItemUI);
            shopItemUI.ItemClicked.AddListener(OnShopItemClicked);
        }
        Debug.Log("ShopUI items set");
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(()=>BuyButtonClicked.Invoke(_currentShopTransaction));
        _sellButton.onClick.AddListener(()=>SellButtonClicked.Invoke(_currentShopTransaction));
        _totalAmountSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }


    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(()=>BuyButtonClicked.Invoke(_currentShopTransaction));
        _sellButton.onClick.RemoveListener(()=>SellButtonClicked.Invoke(_currentShopTransaction));
        _totalAmountSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        foreach (var shopItemUI in _shopItemUIs)
        {
            shopItemUI.ItemClicked.RemoveListener(OnShopItemClicked);
        }
    }

    private void OnShopItemClicked(ShopItemUI shopItemUI)
    {
        _currentItem = shopItemUI.GetItem();
        _currentShopTransaction.ItemName = _currentItem.Name;
        _currentShopTransaction.Amount = _currentItem.Amount;
        _totalAmountSlider.value = 0;
        _totalAmountSlider.maxValue = _currentItem.Amount;
    }

    private void OnSliderValueChanged(float value)
    {
        _currentShopTransaction.Amount = (int)value;
        _totalAmount.text = value.ToString();
        _totalPrice.text = (_currentItem.Price * value).ToString();
    }

    public void UpdateUI(Item shopItem)
    {
        var shopItemUI = _shopItemUIs.Find(x => x.GetItem().Name == shopItem.Name);
        shopItemUI.UpdateItem(shopItem);
        _totalAmountSlider.value = 0;
        _totalAmountSlider.maxValue = shopItem.Amount;
        Debug.Log($"ShopUI updated with {shopItem}");
    }

    public void HideUI()
    {
        Debug.Log("ShopUI is hidden");
        gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        Debug.Log("ShopUI is shown");
        gameObject.SetActive(true);
    }

}
