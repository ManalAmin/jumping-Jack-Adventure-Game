using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip healthClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           SoundManager.instance.PlaySound(healthClip);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);

        }
    }

}
