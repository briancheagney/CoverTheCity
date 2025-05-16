using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharterSlect : MonoBehaviour
{
    public Button[] buttons;
    public Sprite[] happySprites;         // 3 happy face sprites (same order as buttons)
    public Sprite[] sadSprites;           // 3 sad face sprites (same order as buttons)
    public Sprite clickedSprite; //new sprite to switch button to

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            bool isUnlocked = i < unlockedLevel;
            bool isComplete = PlayerPrefs.GetInt("Person" + (i + 1) + "Complete", 0) == 1;

            buttons[i].interactable = isUnlocked;
            buttons[i].image.sprite = isComplete ? happySprites[i] : sadSprites[i];
        }
    }
    public void OpenLevel(int levelId)
    {
        // Find which button was clicked
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        // Find the index of the clicked button in your buttons array
        int clickedIndex = -1;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == clickedButton)
            {
                clickedIndex = i;
                break;
            }
        }

        if (clickedIndex != -1)
        {
            PlayerPrefs.SetInt("Person" + (clickedIndex + 1) + "Complete", 1);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogWarning("Clicked button not found in buttons array");
        }

        SceneManager.LoadScene(levelId);
    }
}
