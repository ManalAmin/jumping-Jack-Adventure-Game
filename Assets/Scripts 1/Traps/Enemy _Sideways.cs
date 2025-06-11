using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
   // [SerializeField] private float movementDistance;
    [SerializeField] private float damage;
    //[SerializeField] private float speed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Player")
       {
            collision.GetComponent<Health>().TakeDamage(damage);

       }
    }

}
