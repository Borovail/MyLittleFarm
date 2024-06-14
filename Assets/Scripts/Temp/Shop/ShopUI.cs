using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Text _productCount;
    [SerializeField] private Image _productImage;
    public Button _buyButton;
    public Button _sellButton;
    public bool _shopOpen = false;

    public void SetProductCount(int count)
    {
        _productCount.text ="Count: " + count.ToString();
    }

    public void SetProductImage(Sprite sprite)
    {
        _productImage.sprite = sprite;
    }

    public void ShowUI()
    {
        _shopOpen = true;
        gameObject.SetActive(true);
    }

    public void HideUI()
    {
        _shopOpen = false;
        gameObject.SetActive(false);
    }
}
