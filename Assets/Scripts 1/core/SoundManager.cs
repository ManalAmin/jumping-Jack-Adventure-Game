using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Assign the singleton instance
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance
            return;
        }
        source = GetComponent<AudioSource>(); // Ens
        if (instance == null)
        {
            instance = this; // Assign the singleton instance
            DontDestroyOnLoad(gameObject);
        }
        else if (instance!=null && instance !=this)         
            Destroy(gameObject);
    }

  

    public void PlaySound(AudioClip _sound)
    {
        if (_sound != null)
        {
            source.clip = _sound; // Assign the sound clip to the AudioSource
            source.loop = true; // Enable looping
            source.Play();

            // Stop looping after 10 seconds
            StartCoroutine(StopSoundAfterDuration(1.5f));
        }
    }

    private IEnumerator StopSoundAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        source.loop = false;
        source.Stop();
    }

}
