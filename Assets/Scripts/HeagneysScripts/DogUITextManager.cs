using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text uiText;
    public Button nextButton;
    public GameObject uiPanel; // Reference to the UI Panel

    private string[] texts = {
        "Welcome to the game!",
        "Your mission is to find the hidden treasure.",
        "Be careful of the obstacles along the way.",
        "Good luck and have fun!"
    };

    private int currentTextIndex = 0;

    void Start()
    {
        // Initialize the text and button
        if (uiText != null)
            uiText.text = texts[currentTextIndex];

        if (nextButton != null)
            nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    void OnNextButtonClicked()
    {
        // Advance to the next text
        currentTextIndex++;
        if (currentTextIndex < texts.Length)
        {
            uiText.text = texts[currentTextIndex];
        }
        else
        {
            // Deactivate the UI Panel
            if (uiPanel != null)
            {
                uiPanel.SetActive(false);
            }
        }
    }
}
