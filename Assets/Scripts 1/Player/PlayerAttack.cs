using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform swordHitPoint; // Adjust this to the player's sword position
    [SerializeField] private float attackRange = 1.0f;  // Adjust the melee attack range
    [SerializeField] private LayerMask enemy;  // Ensure this is set to the layer the enemies are on
    [SerializeField] private AudioClip SwordClip;
    [SerializeField] private int damageAmount = 20;  // Adjust damage dealt

    private Animator anim;
    private movement myMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myMovement = GetComponent<movement>();
    }

    private void Update()
    {
        // If left mouse button is clicked and attack cooldown is over, attack
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && myMovement.canAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        SoundManager.instance.PlaySound(SwordClip);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        // Detect enemies in range
        RaycastHit2D hit = Physics2D.Raycast(swordHitPoint.position, Vector2.right * transform.localScale.x, 1f, enemy);

        if (hit.collider != null)
        {
            AlienEnemy enemy = hit.collider.GetComponent<AlienEnemy>();
            if (enemy != null && Vector2.Distance(transform.position, enemy.transform.position) <= 2f)  // Check if enemy is within 2 units of distance
            {
                enemy.TakeDamage(damageAmount);
            }
        }
    }


    // Called at the moment of the sword strike (via animation event)
   
 public void AttackDamage()
{
    // Detect enemies in a specified range around the sword's hit point
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordHitPoint.position, attackRange, enemy);

    // Log if any enemies are detected
    if (hitEnemies.Length == 0)
    {
        Debug.Log("No enemies detected in OverlapCircle range.");
    }

    // Deal damage to enemies in range
    foreach (Collider2D enemyCollider in hitEnemies)
    {
        AlienEnemy enemy = enemyCollider.GetComponent<AlienEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);  // Damage the enemy
        }
    }
}




    // Draw attack range in editor (for visual debugging)
    private void OnDrawGizmosSelected()
    {
        if (swordHitPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(swordHitPoint.position, attackRange); // Match attack range
    }
}

