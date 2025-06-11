using UnityEngine;

public class Spikehead : EnemyDamage
{
    [Header("Spikehead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;

    private bool attacking;
    private Transform playerTransform;

    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;

    // Reference to the room the player is in
    private room currentRoom;

    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        if (attacking && currentRoom != null && currentRoom.IsPlayerInRoom())
        {
            // Only move towards the player if they are in the same room
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            // Check if Spikehead has reached the player
            if (Vector3.Distance(transform.position, playerTransform.position) < 0.1f)
            {
                Impact();
                Stop();
            }
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer >= checkDelay)
            {
                CheckForPlayer();
                checkTimer = 0;
            }
        }
    }

    private void CheckForPlayer()
    {
        if (currentRoom == null || !currentRoom.IsPlayerInRoom()) return;

        CalculateDirections();

        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null)
            {
                playerTransform = hit.transform;
                attacking = true;
                break;
            }
        }
    }

    private void CalculateDirections()
    {
        directions[0] = transform.right * range;  // Right
        directions[1] = -transform.right * range; // Left
        directions[2] = transform.up * range;     // Up
        directions[3] = -transform.up * range;    // Down
    }

    private void Stop()
    {
        attacking = false;
    }

    private void Impact()
    {
        // Play sound when the Spikehead impacts the player
        SoundManager.instance.PlaySound(impactSound);
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            currentRoom = collision.GetComponent<room>();
        }

        // Ensure sound is NOT played when entering the room
        base.OnTriggerEnter2D(collision);
        Stop();
    }
}
