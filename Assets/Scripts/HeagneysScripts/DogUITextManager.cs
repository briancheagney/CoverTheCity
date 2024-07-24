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
    public GameObject dogDish; // reference the dog dish to enable it's draggability

    private string[] texts = {
        "Hi there! We're going to try to rescue that scared dog.",
        "We'll need to reassure her using food and lastly a blanket.",
        "I'll guide you. Let's do it!"
    };

    private int currentTextIndex = 0;


    // The following variables are for animating the female figure in the first UI.
    public GameObject femaleFigure;
    public GameObject textBubble;
    public GameObject textBubble02;

    private Animator animator;

    void Start()
    {
        // The following is for the animation of the woman in the UI.
        {
            animator = femaleFigure.GetComponent<Animator>();
        }

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
                // uiPanel.SetActive(false); INSTEAD of closing the panel, I'm going to animate the woman and close the text.
                EnableDogDishDragging();

                // Play the scaling and moving animation
                animator.Play("ScaleDownAndMove");

                // Deactivate the text bubble
                textBubble.SetActive(false);
                //textBubble02.SetActive(true);
            }
        }
    }
    private void EnableDogDishDragging()
    {
        if (dogDish != null)
        {
            DragAndDrop dragComponent = dogDish.GetComponent<DragAndDrop>();
            if (dragComponent != null)
            {
                dragComponent.enabled = true;
            }
            else
            {
                Debug.LogError("No DragAndDrop component found on the dog dish.");
            }
        }
        else
        {
            Debug.LogError("Dog dish GameObject is not assigned.");
        }
    }
    void OnScaleDownAndMoveAnimationEnd()
    {
        Debug.Log("Animation finished!");
        // Your code to execute when the animation ends.
        textBubble02.SetActive(true); // opens the second bubble once the animation finishes.
    }
}
