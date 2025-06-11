using UnityEngine;

using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    // Room camera movement
    [SerializeField] private float speed;  // Speed for room transitions
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        // Smoothly move the camera to the target room position
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }

        // This function is called when transitioning to a new room
    public void MoveToNewRoom(Transform _newRoom)
    {
            currentPosX = _newRoom.position.x;  // Set the camera's target X position to the new room's position
    }
}



