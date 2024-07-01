using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    private List<ShopItemUI> _shopItemUIs = new List<ShopItemUI>();
    private ShopItemUI _currentShopItemUI;

    [SerializeField] private Text _totalAmount;
    [SerializeField] private Text _totalPrice;
    [SerializeField] private Slider _totalAmountSlider;

    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _sellButton;

    [SerializeField] private GameObject _shopItemUIPrefab;
    [SerializeField] private Transform _shopLayoutGroup;

    public UnityEvent<Item> BuyButtonClicked { get; private set; } = new ();
    public UnityEvent SellButtonClicked { get; private set; } = new();

    private void OnEnable()
    {
        _buyButton.onClick.AddListener( () =>  BuyButtonClicked.Invoke(_currentShopItemUI.ShopItem));
        _sellButton.onClick.AddListener(SellButtonClicked.Invoke);
        _totalAmountSlider.onValueChanged.AddListener(OnSliderValueChanged);
        foreach (var shopItemUI in _shopItemUIs)
        {
            shopItemUI.ItemClicked.AddListener(OnShopItemClicked);
        }
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener( () =>  BuyButtonClicked.Invoke(_currentShopItemUI.ShopItem));
        _sellButton.onClick.RemoveListener(SellButtonClicked.Invoke);
        _totalAmountSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        foreach (var shopItemUI in _shopItemUIs)
        {
            shopItemUI.ItemClicked.RemoveListener(OnShopItemClicked);
        }
    }

    private void OnShopItemClicked(ShopItemUI shopItemUI)
    {
        _currentShopItemUI = shopItemUI;
        _totalAmountSlider.value = 0;
        _totalAmountSlider.maxValue = shopItemUI.ShopItem.Amount;
    }

    private void OnSliderValueChanged(float value)
    {
        _totalAmount.text = value.ToString();
        _totalPrice.text = (_currentShopItemUI.ShopItem.Price * value).ToString();
    }

    public void UpdateUI(Item shopItem)
    {
        _currentShopItemUI.UpdateItemCount(shopItem.Amount);
        _totalAmountSlider.value = 0;
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
