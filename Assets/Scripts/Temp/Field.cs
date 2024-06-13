using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Crop> _crops;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void Accept(IInteractionVisitor interactionVisitor)
    {
        interactionVisitor.Visit(this);
    }

    public void Harvest(Crop crop)
    {
        _crops.Remove(crop);
        crop.gameObject.SetActive(false);
        _collider.enabled = true;
        Debug.Log("Harvested " + crop.Name);
    }

    public void Plant(Crop crop)
    {
        _crops.Add(crop);
        crop.transform.position = transform.position;
        crop.gameObject.SetActive(true);
        _collider.enabled = false;
        Debug.Log("Planted " + crop.Name);
    }

}
