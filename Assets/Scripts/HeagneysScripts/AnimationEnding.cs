using UnityEngine;

public class AnimationEnding : MonoBehaviour
{
    public GameObject dialogueBox;  // Drag your UI element here in the Inspector
    public void OnAnimationFinished()
    {
        Debug.Log("Animation finished!");
        dialogueBox.SetActive(true);
        // Do whatever you want here
    }
}
