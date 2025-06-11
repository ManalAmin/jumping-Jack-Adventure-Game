using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration = 1f;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private AlienEnemy alienEnemy;

    private void Awake()
    {
        initScale = enemy.localScale;
        alienEnemy = GetComponentInChildren<AlienEnemy>();
    }

    private void Update()
    {
        // If the player is not in sight, keep patrolling
        if (!alienEnemy.PlayerInSight())
        {
            if (movingLeft)
            {
                if (enemy.position.x > leftEdge.position.x)  // Move to left edge
                    MoveInDirection(-1);
                else
                    DirectionChange();
            }
            else
            {
                if (enemy.position.x < rightEdge.position.x)  // Move to right edge
                    MoveInDirection(1);
                else
                    DirectionChange();
            }
        }
        else
        {
            // If player is in sight, stop movement and animation
            anim.SetBool("moving", false);
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);  // Stop moving animation
        idleTimer += Time.deltaTime;    // Start idle timer

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;   // Toggle direction after idle
            idleTimer = 0;              // Reset idle timer
        }
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;  // Reset idle timer
        anim.SetBool("moving", true);  // Set moving animation

        // Make the enemy face the right direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        // Move in the direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
                                     enemy.position.y, enemy.position.z);
    }
}
