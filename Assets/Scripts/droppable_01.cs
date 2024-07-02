using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOverlap : MonoBehaviour

{
    public AudioClip overlapSound;
    public GameObject popupPanel;// Reference to the popup panel
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
        if (popupPanel == null)
        {
            Debug.LogError("No popup panel assigned.");
        }
        else
        {
            popupPanel.SetActive(false); // Ensure the popup is initially inactive
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
            if (popupPanel != null)
            {
                popupPanel.SetActive(true); // Show the popup panel
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Triangle"))
        {
            Debug.Log("Square is no longer overlapping the triangle!");
            if (popupPanel != null)
            {
                popupPanel.SetActive(false); // Hide the popup panel
            }
            // Add your logic here
        }
    }
}

