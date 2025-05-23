using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StorySelectionManager : MonoBehaviour
{
    public Button story1Button;
    public Button story2Button;
    public Button story3Button;

    void Start()
    {
        // Load the completion states
        bool isStory1Completed = PlayerPrefs.GetInt("Story1Completed", 0) == 1;
        bool isStory2Completed = PlayerPrefs.GetInt("Story2Completed", 0) == 1;
        bool isStory3Completed = PlayerPrefs.GetInt("Story3Completed", 0) == 1;

        // Enable/Disable buttons based on completion states
        story1Button.interactable = true;  // Story1 button is always enabled
        story2Button.interactable = isStory1Completed;  // Enable Story2 button if Story1 is completed
        story3Button.interactable = isStory2Completed;  // Enable Story3 button if Story2 is completed

        // Add listeners for buttons
        story1Button.onClick.AddListener(() => PlayStory(1));
        story2Button.onClick.AddListener(() => PlayStory(2));
        story3Button.onClick.AddListener(() => PlayStory(3));
    }

    void PlayStory(int storyNumber)
    {
        // Load the story scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Story" + storyNumber);

        // Mark the story as completed
        PlayerPrefs.SetInt("Story" + storyNumber + "Completed", 1);
        PlayerPrefs.Save();
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Scene01_Start");
    }
}
