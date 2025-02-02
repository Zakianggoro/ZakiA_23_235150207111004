using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform

    void Update()
    {
        // Set the camera's position to the player's position
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}