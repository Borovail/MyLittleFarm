using UnityEngine;
using UnityEngine.UI;

public class Crop : MonoBehaviour, IInteractable
{
    public string Name;
    public Sprite Sprite;
    public float Price;
    public Field _field;

    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void Start()
    {
        _field = GetComponentInParent<Field>();
    }

    public void Accept(IInteractionVisitor interactionVisitor) => interactionVisitor.Visit(this);
}
