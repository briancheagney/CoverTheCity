using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Button nextButton;
    public string[] dialogueLines;
    private int currentLineIndex = 0;
    private int clickCount = 0;
    public int clicksToActivateScript = 3;
    public GameObject scriptToActivate;
    public GameObject dialoguePanel;

    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
        UpdateDialogue();
    }

    void UpdateDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

    void OnNextButtonClick()
    {
        clickCount++;
        if (clickCount >= clicksToActivateScript)
        {
            if (scriptToActivate != null)
            {
                // Activate the GameObject containing the MoveObject script
                scriptToActivate.SetActive(true);
            }
        }

        currentLineIndex++;
        UpdateDialogue();
    }
}
