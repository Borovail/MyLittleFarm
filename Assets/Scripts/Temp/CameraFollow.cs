using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float SmoothSpeed = 1f; 
    public Vector2 InnerBounds; 

    private Vector3 _velocity = Vector3.zero; 

    void LateUpdate()
    {
        if (Player == null)
        {
            Debug.LogWarning("Player is not set in CameraFollow script");
            return;
        }

        float leftBound = transform.position.x - InnerBounds.x;
        float rightBound = transform.position.x + InnerBounds.x;
        float topBound = transform.position.y + InnerBounds.y;
        float bottomBound = transform.position.y - InnerBounds.y;

        if(Player.position.x < leftBound || Player.position.x > rightBound || Player.position.y > topBound || Player.position.y < bottomBound)
        {
            Vector3 desiredPosition = new Vector3(Player.position.x, Player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, SmoothSpeed);
        }
    }
}
