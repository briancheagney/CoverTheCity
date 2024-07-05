using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    private DragAndDrop dragAndDrop;
    private GameObject popupPanel;

    private GameManager gameManager;

    void Start()
    {
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

        // Notify the GameManager
        if (gameManager != null)
        {
            Debug.Log("Notifying GameManager");
            gameManager.ItemPlaced();
        }
        else
        {
            Debug.LogError("GameManager is null when trying to call ItemPlaced()");
        }

        //if (dragAndDrop != null)
        //{
        //    dragAndDrop.SetDragging(true); // Re-enable dragging
        //    dragAndDrop.enabled = true; // Enable the DragAndDrop script
        //}
    }
}
