using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemy : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private int maxHealth = 100;  // Set starting health
    private int currentHealth;
    private room enemyRoom;
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header("Sound")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip deathSound;  // Add this for enemy death sound

    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        currentHealth = maxHealth;  // Initialize enemy health
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    public bool IsInSameRoom(room playerRoom)
    {
        return enemyRoom == playerRoom;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Check if the player is in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown && playerHealth.currentHealth > 0)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Alienattack");
                SoundManager.instance.PlaySound(attackSound);
                Attack();
            }

            // Stop patrol if player is in sight
            if (enemyPatrol != null)
            {
                enemyPatrol.enabled = false;  // Stop enemy patrol when attacking
            }

            anim.SetBool("moving", false);  // Stop moving animation when attacking
        }
        else
        {
            if (enemyPatrol != null)
            {
                enemyPatrol.enabled = true;  // Resume patrol if player is out of sight
            }
        }
    }

    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void Attack()
    {
        // Play attack sound
        if (attackSound != null)
        {
            SoundManager.instance.PlaySound(attackSound);
        }

        // Damage the player
        if (PlayerInSight())
        {

            playerHealth.TakeDamage(damage);
        }
    }

    // Add the TakeDamage method here to handle enemy damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        // Play death animation or any logic here
        anim.SetTrigger("die");
        GetComponent<Collider2D>().enabled = false;  // Disable enemy collider

        // Play the enemy death sound, if available
        if (deathSound != null)
        {
            SoundManager.instance.PlaySound(deathSound);
        }

        // Optionally, destroy the enemy object after death animation
        Destroy(gameObject, 1.5f);  // Wait for death animation to finish
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}