using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Selectable : MonoBehaviour, ISelectable
{
    public Color HighlightColor = new Color(239f/255f, 237f/255f, 29f/255f, 210f/255f);
    public float ScaleFactor = 1.1f;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private Vector3 _originalScale;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
        _originalScale = transform.localScale;
    }

    private void Highlight() => _spriteRenderer.color = HighlightColor;
    private void UnHighlight() => _spriteRenderer.color = _originalColor;

    private void ScaleUp() => transform.localScale = _originalScale * ScaleFactor;
    private void ScaleDown() => transform.localScale = _originalScale;

    public void Select()
    {
        Highlight();
        ScaleUp();
        Debug.Log("Selected: " + name);
    }

    public void Deselect()
    {
        UnHighlight();
        ScaleDown();
        Debug.Log("Deselected: " + name);
    }
}


