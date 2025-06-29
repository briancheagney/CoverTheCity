using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveNewObject : MonoBehaviour
{
    public Button moveButton; // Reference to the UI Button
    public GameObject oldObject; // Reference to the old object
    public GameObject newObject; // Reference to the new object to appear and move
    public GameObject spriteObject; // Reference to the object with the sprite to change
    public Sprite newSprite; // The new sprite to switch to
    public Vector3 targetPosition; // Target position to move to
    public float speed = 2f; // Speed of movement
    public float delay = 2f; // Delay before moving
    public GameObject enddialoguebox; //this is the last dialogue box that will give us a button to take us to the character select
    public float fadeDuration = 1f;

    private bool shouldMove = false;

    void Start()
    {
        // Add a listener to the button to call the StartMove function when clicked
        moveButton.onClick.AddListener(StartMove);
    }

    void Update()
    {
        if (shouldMove && newObject != null)
        {
            // Move the new object towards the target position
            newObject.transform.position = Vector3.MoveTowards(newObject.transform.position, targetPosition, speed * Time.deltaTime);

            // Stop moving if the object reaches the target position
            if (newObject.transform.position == targetPosition)
            {
                shouldMove = false;
                newObject.SetActive(false); // Make the new object disappear
                ChangeSprite(); // Change the sprite of the spriteObject
            }
        }
    }

    void StartMove()
    {
        // Make the old object disappear
        if (oldObject != null)
        {
            oldObject.SetActive(false);
        }

        // Make the new object appear
        if (newObject != null)
        {
            newObject.SetActive(true);
            StartCoroutine(DelayMove());
        }
    }

    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(delay);
        shouldMove = true;
    }

    void ChangeSprite()
    {
        if (spriteObject != null && newSprite != null)
        {
            // Stop the animation
            Animator animator = spriteObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }

            // Change the sprite
            SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;
            }
            if (enddialoguebox != null)
            {
                enddialoguebox.SetActive(true);
                StartCoroutine(FadeIn(enddialoguebox.GetComponent<CanvasGroup>()));
            }
        }
    }


    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
