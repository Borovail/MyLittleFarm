using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{

    [SerializeField] private ShopUI _shopUI;

    private Crop crop;

    public void DeInteract()
    {
        _shopUI.HideUI();
        Debug.Log("Deactivating shop UI");
    }

    public void Interact()
    {
        _shopUI.ShowUI();
        Debug.Log("Activating shop UI");
    }

    private void BuyItem(Product product)
    {

        Debug.Log("Buy product: " +  product);
    }
                                                                                
    private void SellItem(Product product)
    {
        Debug.Log("Sell product: " + product);
    }

}
