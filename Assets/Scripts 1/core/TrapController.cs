using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrapController : MonoBehaviour
{
    public GameObject[] traps; 
    public GameObject[] enemies; // Separate array for enemies
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            ActivateTraps();
            ActivateEnemies();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            DeactivateTraps();
            DeactivateEnemies();
        }
    }

    private void ActivateTraps()
    {
        foreach (GameObject trap in traps)
        {
            trap.SetActive(true);
        }
    }

    private void DeactivateTraps()
    {
        foreach (GameObject trap in traps)
        {
            trap.SetActive(false);
        }
    }

    private void ActivateEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true); // Activating enemy
        }
    }

    private void DeactivateEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false); // Deactivating enemy
        }
    }
}