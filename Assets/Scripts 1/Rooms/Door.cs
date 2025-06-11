using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private cameracontroller cam;
    [SerializeField] private string targetTag = "Player"; // Added targetTag variable

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player") // Check for the player's tag
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom); // Move the camera to the next room
            }
            else
            {
                cam.MoveToNewRoom(previousRoom); // Move the camera to the previous room
            }
        }
    }

}
