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
        _buyButton.onClick.AddListener(EventBus.BuyButtonClickedInvoke);
        _sellButton.onClick.AddListener(EventBus.SellButtonClickedInvoke);
        EventBus.ItemBought.AddListener(OnItemBought);
        EventBus.ItemSold.AddListener(OnItemSold);



        //EventBus.ItemBought.AddListener(OnItemSold);
        //EventBus.ItemSold.AddListener(OnItemBought);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(EventBus.BuyButtonClickedInvoke);
        _sellButton.onClick.RemoveListener(EventBus.SellButtonClickedInvoke);
        EventBus.ItemBought.RemoveListener(OnItemBought);
        EventBus.ItemSold.RemoveListener(OnItemSold);


        //EventBus.ItemBought.RemoveListener(OnItemSold);
        //EventBus.ItemSold.RemoveListener(OnItemBought);
    }

    private void OnItemSold(Item item)
    {
        SetProductImage(null);
        SetProductCount(0);
    }

    private void OnItemBought(Item item)
    {
        SetProductCount(item._amount);
        SetProductImage(item._crop.Sprite);
    }

    public void SetProductCount(int count)
    {
        _productCount.text = "Count: " + count.ToString();
    }

    public void SetProductImage(Sprite sprite)
    {
        _productImage.sprite = sprite;
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
