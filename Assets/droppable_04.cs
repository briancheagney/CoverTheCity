using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOverlap : MonoBehaviour

{
    public AudioClip overlapSound;
    private AudioSource audioSource;

    void Start()
    {
        Debug.Log("DragSquare script started");
        // Manually assign the AudioSource if it's not assigned in the Inspector
        if (audioSource == null)
        {
            audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource component found on the AudioManager GameObject.");
            }
        }

        if (overlapSound == null)
        {
            Debug.LogError("No AudioClip assigned to overlapSound.");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Triangle"))
        {
            Debug.Log("Square is overlapping the triangle!");
            // Add your logic here
            if (audioSource != null && overlapSound != null)
            {
                audioSource.PlayOneShot(overlapSound);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Triangle"))
        {
            Debug.Log("Square is no longer overlapping the triangle!");
            // Add your logic here
        }
    }
}

