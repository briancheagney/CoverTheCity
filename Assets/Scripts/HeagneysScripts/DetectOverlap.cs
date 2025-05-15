using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectOverlap : MonoBehaviour
{
    public AudioClip overlapSound;
    public GameObject popupPanel; // Reference to the popup panel
    private AudioSource audioSource;

    [SerializeField] // Allows DragAndDrop to be set in the Inspector while remaining private
    private DragAndDrop dragAndDrop;

    private PopUpController popupController;
    private bool isOverlapHandled = false; // Track if overlap has been handled

    private GameManager gameManager;

    public GameObject bagobjecttoshow;
    public GameObject objectToShow;
    public GameObject objectToHide;
    public GameObject objectToDraggable; //make this object draggable.
    public int dogAnimInt; //If this is zero then no dogwalk; if it's 1, then dogwalk.
    //public GameManager gameManager;
    void Start()
    {
        Debug.Log("DetectOverlap script started");

        // Check to see if gameManager exists
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("No GameManager found in the scene.");
        }
        else
        {
            Debug.Log("GameManager found: " + gameManager.name);
        }

        // Manually assign the AudioSource if it's not assigned in the Inspector
        if (audioSource == null)
        {
            audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource component found on the AudioManager GameObject.");
            }
        }

        if (overlapSound == null)
        {
            Debug.LogError("No AudioClip assigned to overlapSound.");
        }

        if (popupPanel == null)
        {
            Debug.LogError("No popup panel assigned.");
        }
        else
        {
            popupPanel.SetActive(false); // Ensure the popup is initially inactive
            popupController = popupPanel.GetComponent<PopUpController>();
            if (popupController == null)
            {
                Debug.LogError("No PopupController component found on the popup panel.");
            }
        }

        if (dragAndDrop == null)
        {
            dragAndDrop = GetComponent<DragAndDrop>();
            if (dragAndDrop == null)
            {
                Debug.LogError("No DragAndDrop component found on this GameObject.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called");

        if (!isOverlapHandled && other.gameObject.CompareTag("Triangle"))
        {

            Debug.Log("object is overlapping the bag!");
            if (audioSource != null && overlapSound != null)
            {
                audioSource.PlayOneShot(overlapSound);
            }

            if (popupPanel != null)
            {
                Debug.Log("Setting popupPanel active");
                popupPanel.SetActive(true); // Show the popup panel
                popupController.Initialize(); // Initialize the popup state if needed
            }

            if (dragAndDrop != null)
            {
                //draggable_02.SetDragging(false);
                dragAndDrop.SetDragging(false); // Disable dragging
                dragAndDrop.enabled = false; // Disable the DragAndDrop script
                //start new code
                DragAndDrop[] allDraggables = FindObjectsOfType<DragAndDrop>();
                foreach (DragAndDrop d in allDraggables)
                {
                    d.SetDragging(false);
                    d.enabled = false;
                }
                //end new code
            }
            isOverlapHandled = true; // Mark overlap as handled

            if (bagobjecttoshow != null)
            {
                Debug.Log("Showing Object");
                bagobjecttoshow.SetActive(true);
                //objectToHide.SetActive(false);
            }


            if (objectToShow != null)
            {
                Debug.Log("Showing Object");
                objectToShow.SetActive(true);
                objectToHide.SetActive(false);
                Debug.Log("dogAnimInt =" + dogAnimInt);
                if (dogAnimInt == 1)
                {
                    gameManager.EnableDogWalk();
                }
                if (dogAnimInt == 2)
                {
                    gameManager.DogCover();
                }
                DragAndDrop dragComponent = objectToDraggable.GetComponent<DragAndDrop>();
                if (dragComponent != null)
                {
                    dragComponent.enabled = true;
                    objectToDraggable.SetActive(true);
                }
                else
                {
                    Debug.LogError("No DragAndDrop component found on the dog Food.");
                }
            }

            // Notify the GameManager
            //if (gameManager != null)
            //{
            //    Debug.Log("Notifying GameManager");
            //gameManager.ItemPlaced();
            //}
            //else
            //{
            //Debug.LogError("GameManager is null when trying to call ItemPlaced()");
            //}

            // Disable interaction with the square
            //EventSystem.current.SetSelectedGameObject(null);
            //dragAndDrop.enabled = false; // Disable the DragAndDrop script

            // Destroy the green square after the overlap
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Triangle"))
        {
            isOverlapHandled = false; // Reset overlap handling state
        }
    }
}



