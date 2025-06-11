using UnityEngine;

public class room : MonoBehaviour
{
    private bool playerInRoom;
    private int enemyCount = 0;  // Track the number of enemies in the room

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRoom = true;  // Player enters the room
        }

        if (collision.CompareTag("Enemy"))  // Consistent enemy tag check
        {
            enemyCount++;  // Increment enemy count when an enemy enters
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRoom = false;  // Player leaves the room
        }

        if (collision.CompareTag("Enemy"))  // Consistent enemy tag check
        {
            enemyCount--;  // Decrement enemy count when an enemy leaves
            if (enemyCount < 0) enemyCount = 0;  // Ensure count doesn't go negative
        }
    }

    public bool IsPlayerInRoom()
    {
        return playerInRoom;
    }

    public bool IsEnemyInRoom()
    {
        return enemyCount > 0;  // Returns true if there are one or more enemies in the room
    }
}
