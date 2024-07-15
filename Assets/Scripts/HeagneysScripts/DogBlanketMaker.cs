using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBlanketMaker: MonoBehaviour
{
    private DragAndDrop dragAndDrop;
    private GameObject popupPanel;

    private GameManager gameManager;
    private DogController dogController;

    void Start()
    {
        // Check to see if dogController exists
        dogController = FindObjectOfType<DogController>();
        if (dogController == null)
        {
            Debug.LogError("No DogController found in the scene.");
        }
        else
        {
            Debug.Log("DogController found: " + dogController.name);
        }


        // Check to see if gameManager exists
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("No GameManager found in the scene.");
        }
        else
        {
            Debug.Log("GameManager found: " + gameManager.name);
        }

        // Find the DragAndDrop component in the scene
        dragAndDrop = FindObjectOfType<DragAndDrop>();
        if (dragAndDrop == null)
        {
            Debug.LogError("No DragAndDrop component found in the scene.");
        }

        // Get the popup panel GameObject
        popupPanel = gameObject;
    }
    public void Initialize()
    {
        // Reset any states or UI elements in the popup if needed
        // This method can be extended to reset other UI elements in the popup
    }

    public void OnCloseButtonClick()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false); // Hide the popup panel
        }

        // Notify the dogController
        if (dogController != null)
        {
            Debug.Log("Notifying dogController");
            dogController.CoverDog();
        }
        else
        {
            Debug.LogError("dogController is null when trying to call CoverDog()");
        }

        //if (dragAndDrop != null)
        //{
        //    dragAndDrop.SetDragging(true); // Re-enable dragging
        //    dragAndDrop.enabled = true; // Enable the DragAndDrop script
        //}
    }
}
