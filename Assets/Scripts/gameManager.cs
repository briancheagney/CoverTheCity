using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalItemsToPlace = 4; // Total items to be placed
    private int itemsPlaced = 0; // Counter for items placed
    private int doggieitemsPlaced = 0; // Counter for doggie items placed
    public GameObject dogFood;
    public GameObject blanket;
    public GameObject dogBowl2;
    public GameObject dogFood2;
    public DogController dogController; // Reference to the DogController script

    private void Awake()
    {
        Debug.Log("Game Manager Enabled!");
        // Ensure only one instance of GameManager exists
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }



    public void ItemPlaced()
    {
        itemsPlaced++;
        Debug.Log("Items placed: " + itemsPlaced);
        if (itemsPlaced >= totalItemsToPlace)
        {
            AdvanceToNextScene();
        }
    }

    public void DoggieItemPlaced()
    {
        doggieitemsPlaced++;
        Debug.Log("Doggie Items placed: " + doggieitemsPlaced);
        if (doggieitemsPlaced == 1)
        {
            EnableDogFoodDrag();
            Debug.LogError("EnableDogFoodDrag called");

        }
        else if (doggieitemsPlaced == 2)
        {
            EnableDogWalk();
        }
    }

    private void EnableDogFoodDrag()
    {
        if (dogFood != null)
        {
            DragAndDrop dragComponent = dogFood.GetComponent<DragAndDrop>();
            if (dragComponent != null)
            {
                dragComponent.enabled = true;
                dogBowl2.SetActive(true);
            }
            else
            {
                Debug.LogError("No DragAndDrop component found on the dog Food.");
            }
        }
        else
        {
            Debug.LogError("Dog Food GameObject is not assigned.");
        }
    }

    public void EnableDogWalk()
    {
        if (blanket != null)
        {
            DragAndDrop dragComponent = blanket.GetComponent<DragAndDrop>();
            if (dragComponent != null)
            {
                //dragComponent.enabled = true; //I disabled this so that the blanket isn't draggable until the dog starts eating.
                dogFood2.SetActive(true); //This is the dogfood dish with food in it!
                dogController.StartWalking(); // Start the dog walking
            }
            else
            {
                Debug.LogError("No DragAndDrop component found on the blanket.");
            }
        }
        else
        {
            Debug.LogError("blanket GameObject is not assigned.");
        }
    }


    public void EnableBlanketDrag()
    {
        if (blanket != null)
        {
            DragAndDrop dragComponent = blanket.GetComponent<DragAndDrop>();
            if (dragComponent != null)
            {
                dragComponent.enabled = true; //This is the new place where the blanket is enabled to be draggable.
                //dogFood2.SetActive(true);
                //dogController.StartWalking(); // Start the dog walking
            }
            else
            {
                Debug.LogError("No DragAndDrop component found on the blanket.");
            }
        }
        else
        {
            Debug.LogError("blanket GameObject is not assigned.");
        }
    }

    private void AdvanceToNextScene()
    {
        // Assuming the next scene is the next in the build order
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

