using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Text _productCount;
    [SerializeField] private Image _productImage;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _sellButton;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(() => BuyItem());
        _sellButton.onClick.AddListener(() => SellItem());
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveAllListeners();
        _sellButton.onClick.RemoveAllListeners();
    }

    private void BuyItem()
    {
        Debug.Log("Buy product");
    }

    private void SellItem()
    {
        Debug.Log("Sell product");
    }

    public void ShowUI()
    {
        gameObject.SetActive(true);
    }

    public void HideUI()
    {
        gameObject.SetActive(false);
    }


   
}
