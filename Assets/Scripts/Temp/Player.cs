using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float RaycastDistance = 1f;
    public float RaycastDrawTime = 2f;

    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private Inventory _inventory;

    private Rigidbody2D _rigidbody;
    private InputSystem_Actions _playerInputsActions;

    private ISelectable _currentSelectable;
    private IInteractable _currentInteractable;
    private Collider2D _currentCollider;

    private CommandInvoker _commandInvoker;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _playerInputsActions = new InputSystem_Actions();

        _commandInvoker = new CommandInvoker();
    }

    private void OnEnable()
    {
        _playerInputsActions.Player.Enable();
        _playerInputsActions.Player.Interact.performed += OnInteract;
        _playerInputsActions.Player.Menu.performed += OnMenu;
    }


    private void OnDisable()
    {
        _playerInputsActions.Player.Interact.performed -= OnInteract;
        _playerInputsActions.Player.Menu.performed -= OnMenu;
        _playerInputsActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        var direction = _playerInputsActions.Player.Move.ReadValue<Vector2>();
        Move(direction);
        if (direction == Vector2.zero) return;

        var raycastHit = Physics2D.Raycast(transform.position, direction, RaycastDistance, _interactableLayer);
        Debug.DrawRay(transform.position, direction * RaycastDistance, Color.red, RaycastDrawTime);

        if (raycastHit.collider != _currentCollider)
        {
            _currentCollider = raycastHit.collider;

            _currentInteractable = _currentCollider?.GetComponent<IInteractable>();

            ///подсвечиваем объект
            _currentSelectable?.Deselect();
            _currentSelectable = _currentCollider?.GetComponent<ISelectable>();
            _currentSelectable?.Select();
        }

    }


    private void OnMenu(InputAction.CallbackContext obj) => Debug.Log("Open menu");
    private void OnInteract(InputAction.CallbackContext obj)
    {
        PlayerInteractionVisitor visitor = new PlayerInteractionVisitor(_inventory, _commandInvoker);
        _currentInteractable?.Accept(visitor);
    }
    private void Move(Vector2 direction) => _rigidbody.velocity = direction * MoveSpeed;

}
