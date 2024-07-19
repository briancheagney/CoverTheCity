using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public Button unlockButton;
    public int sceneToLoadIndex; // The build index of the scene to load

    void Start()
    {
        unlockButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        UnlockNewLevel();
        LoadNewScene();
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene(sceneToLoadIndex);
    }
}