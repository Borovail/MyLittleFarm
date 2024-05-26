using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float Speed = 1f;

    [SerializeField] private FixedJoystick _joystick;

    private Rigidbody2D _rigidbody;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_joystick.Horizontal * Speed, _joystick.Vertical * Speed);
    }



    private void OnValidate()
    {
        EnsureJoystickAssigned();
        EnsureRigidbodyAssigned();
    }

    private void EnsureJoystickAssigned()
    {
        if(_joystick != null) return;

        _joystick = FindFirstObjectByType<FixedJoystick>();

        if (_joystick==null)
        {
            Debug.LogError("No Joystick found in the scene.");
        }
        else
        {
            Debug.Log("Joystick has been added automatically.");
        }
    }

    private void EnsureRigidbodyAssigned()
    {
        if (_rigidbody != null) return;

        _rigidbody = GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();

        if (_rigidbody == null)
        {
            Debug.LogError("Failed to add or find Rigidbody2D.");
        }
        else
        {
            _rigidbody.gravityScale = 0f;
            Debug.Log("Rigidbody2D has been added automatically.");
        }
    }





}
