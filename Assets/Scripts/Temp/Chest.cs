using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(SpriteRenderer))]
public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private float Gold;
    [SerializeField] private Sprite _openChestSprite;

    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Accept(IInteractionVisitor interactionVisitor)
    {
        interactionVisitor.Visit(this);
    }

    public void Open()
    {
        _collider.enabled = false;
        _spriteRenderer.sprite = _openChestSprite;
        _eventBus.PlayerGoldChangedInvoke(Gold);
        Debug.Log("Chest opened");
    }

        


}
