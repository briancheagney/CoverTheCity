using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    private bool isDialogueActive = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDialogueActive)
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);
            if (hit && hit.collider.gameObject == gameObject)
            {
                isDialogueActive = true;
                dialoguePanel.SetActive(true);
            }
        }
    }
}
