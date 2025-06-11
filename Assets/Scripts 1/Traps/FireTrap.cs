using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    private Animator anim;

    [Header("SFX")]
    [SerializeField] private AudioClip firetrapSound;
    private void Awake()
    {
        anim = GetComponent<Animator>(); // Make sure this refers to FireTrap
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.CompareTag("Player"))
        {
            // Apply damage to the player's health component
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                anim.SetTrigger("ActivateTrap");
                SoundManager.instance.PlaySound(firetrapSound);
                Debug.Log("Player damaged by fire trap or fire!");

            }
            else
            {
                Debug.LogWarning("Player does not have a Health component!");
            }
        }
    }
    private IEnumerator FlashDamageEffect()
    {
        // Example effect: change color to red for a brief moment
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.2f); // Flash duration
        renderer.color = Color.white;
    }
}
