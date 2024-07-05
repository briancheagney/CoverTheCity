using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalItemsToPlace = 4; // Total items to be placed
    private int itemsPlaced = 0; // Counter for items placed

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

    private void AdvanceToNextScene()
    {
        // Assuming the next scene is the next in the build order
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

