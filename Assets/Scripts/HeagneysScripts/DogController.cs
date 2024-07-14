using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public Transform targetPosition; // The position the dog should walk to
    public float speed = 2.0f; // Speed of the dog's movement
    public float scaleSpeed = 1.0f; // Speed of scaling

    private bool shouldMove = false;
    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale * 2; // Double the size
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
        shouldMove = true;
    }

    private void MoveDog()
    {
        float step = speed * Time.deltaTime; // Calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);

        // Check if the dog has reached the target position
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.001f)
        {
            shouldMove = false;
            animator.Play("DogIdle"); // Play the Idle animation
            //transform.localScale = originalScale; // Reset the scale to original size
        }
    }
    private void ScaleDog()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

        // Check if the dog has reached the target scale
        if (Vector3.Distance(transform.localScale, targetScale) < 0.001f)
        {
            transform.localScale = targetScale; // Ensure exact target scale is set
        }
    }
}
