using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Crop _initialCrop;
    [SerializeField] private Text _productCount;
    [SerializeField] private Image _productImage;
    public Button _buyButton;
    public Button _sellButton;
    public bool _shopOpen = false;

    private void OnEnable()
    {
        EventBus.AddItemToShop.AddListener(OnItemAdded);
        EventBus.RemoveItemFromShop.AddListener(OnItemRemoved);
    }

    private void OnDisable()
    {
        EventBus.AddItemToShop.RemoveListener(OnItemAdded);
        EventBus.RemoveItemFromShop.RemoveListener(OnItemRemoved);
    }

    private void Start()
    {
        SetProductImage(_initialCrop.Sprite);
        SetProductCount(1);
    }

    private void OnItemAdded(Item item)
    {
        SetProductCount(1);
        SetProductImage(item._crop.Sprite);
    }

    private void OnItemRemoved(Item item)
    {
        SetProductCount(0);
        SetProductImage(null);
    }

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
