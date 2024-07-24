using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveObject : MonoBehaviour
{
    public Button moveButton; // Reference to the UI Button
    public Vector3 targetPosition; // Target position to move to
    public float speed = 2f; // Speed of movement
    public float delay = 2f; // Delay before moving
    public GameObject newObject; // Reference to the new object to appear

    private bool shouldMove = false;

    void Start()
    {
        // Add a listener to the button to call the StartMove function when clicked
        moveButton.onClick.AddListener(StartMove);
    }

    void Update()
    {
        if (shouldMove)
        {
            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Stop moving if the object reaches the target position
            if (transform.position == targetPosition)
            {
                shouldMove = false;
                // Make the current object disappear
                gameObject.SetActive(false);
                // Make the new object appear
                if (newObject != null)
                {
                    newObject.SetActive(true);
                }
            }
        }
    }

    void StartMove()
    {
        StartCoroutine(DelayMove());
    }

    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(delay);
        shouldMove = true;
    }
}
