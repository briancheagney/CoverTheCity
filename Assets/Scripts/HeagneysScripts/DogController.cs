using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public Transform targetPosition; // The position the dog should walk to
    public float speed = 2.0f; // Speed of the dog's movement
    public float scaleSpeed = 1.0f; // Speed of scaling
    public float scaleAmount;
    public int targetSortingOrder = 5; // The target Order in Layer

    private bool shouldMove = false;
    private Vector3 originalScale;
    private Vector3 targetScale;
    private SpriteRenderer spriteRenderer;

    private GameManager gameManager;
    public GameObject blanket3;

    void Start()
    {
        originalScale = transform.localScale;
        //Debug.Log("original scale = " + originalScale);
        targetScale = originalScale * scaleAmount; // changes the scale
        //Debug.Log("target scale = " + targetScale);
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    void Update()
    {
        if (shouldMove)
        {
            MoveDog();
            ScaleDog();
        }
    }

    public void StartWalking()
    {
        animator.Play("DogWalk"); // Play the Walk animation
        spriteRenderer.sortingOrder = targetSortingOrder; // Change the Order in Layer to the target sorting order
        shouldMove = true;
    }

    private void MoveDog()
    {
        float step = speed * Time.deltaTime; // Calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);
        //Debug.Log("current scale = " + transform.localScale);
        //transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, step);
        //transform.localScale = transform.localScale * scaleAmount;

        // Check if the dog has reached the target position
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.001f)
        {
            shouldMove = false;
            animator.Play("DogEat2"); // Play the Eat animation
            //transform.localScale = originalScale; // Reset the scale to original size
            gameManager.EnableBlanketDrag();
        }
    }
    private void ScaleDog()
    {
        //Debug.Log("current scale = " + transform.localScale);
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

        // Check if the dog has reached the target scale
        if (Vector3.Distance(transform.localScale, targetScale) < 0.001f)
        {
            transform.localScale = targetScale; // Ensure exact target scale is set
        }
    }

    public void CoverDog()
    {
        animator.Play("DogCovered"); // Show Dog in blanket with tail wagging
        //put reference to gamemanager open popup here

    }

}
