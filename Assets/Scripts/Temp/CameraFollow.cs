using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;
    public float SmoothSpeed = 1f; 
    public Vector2 InnerBounds; 

    private Vector3 _velocity = Vector3.zero;

    public void Initialize(Transform player)
    {
        _player = player;
    }

    private void LateUpdate()
    {
        if (_player == null)
        {
            Debug.LogWarning("_player is not set in CameraFollow script");
            return;
        }

        float leftBound = transform.position.x - InnerBounds.x;
        float rightBound = transform.position.x + InnerBounds.x;
        float topBound = transform.position.y + InnerBounds.y;
        float bottomBound = transform.position.y - InnerBounds.y;

        if(_player.position.x < leftBound || _player.position.x > rightBound || _player.position.y > topBound || _player.position.y < bottomBound)
        {
            Vector3 desiredPosition = new Vector3(_player.position.x, _player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, SmoothSpeed);
        }
    }
}
