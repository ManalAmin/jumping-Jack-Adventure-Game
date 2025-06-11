using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void CheckRespawn()
    {
        if (currentCheckpoint == null)
        {
            uiManager.GameOver();
            //show game over screen
            return;
        }

        playerHealth.Respawmn();
        transform.position = currentCheckpoint.position;
     
        Camera.main.GetComponent<cameracontroller>().MoveToNewRoom(currentCheckpoint.parent);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");




        }

    }
}