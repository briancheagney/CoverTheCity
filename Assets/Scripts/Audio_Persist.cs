using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip mainTheme;          // Music for scenes 1 and 2
    public AudioClip vignetteTheme;      // Music for scenes 3–5
    private AudioSource audioSource;

    private string[] vignetteScenes = { "Scene04_Stry1_Pack", "Scene06_Stry2_Apt", "Scene07_Stry3_Dog_02" };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Scene01_Start" || scene.name == "Scene02_CharSelect B" || scene.name == "Scene03_Stry1_Intro")
        {
            // Play main theme if not already playing
            if (audioSource.clip != mainTheme)
            {
                audioSource.clip = mainTheme;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else if (IsVignetteScene(scene.name))
        {
            // Play vignette music if not already playing
            if (audioSource.clip != vignetteTheme)
            {
                audioSource.clip = vignetteTheme;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    bool IsVignetteScene(string sceneName)
    {
        foreach (string name in vignetteScenes)
        {
            if (sceneName == name)
                return true;
        }
        return false;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
