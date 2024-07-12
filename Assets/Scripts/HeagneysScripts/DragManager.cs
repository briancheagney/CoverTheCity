using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public GameObject dogDish;
    public GameObject dogFood;
    public GameObject blanket;

    private int currentDragIndex = 0;

    private void Start()
    {
        // Enable only the dog dish at the start
        SetDraggable(dogDish, true);
        SetDraggable(dogFood, false);
        SetDraggable(blanket, false);
    }

    public void OnObjectPlaced(string objectName)
    {
        if (objectName == dogDish.name && currentDragIndex == 0)
        {
            currentDragIndex++;
            SetDraggable(dogFood, true);
        }
        else if (objectName == dogFood.name && currentDragIndex == 1)
        {
            currentDragIndex++;
            SetDraggable(blanket, true);
        }
    }

    private void SetDraggable(GameObject obj, bool draggable)
    {
        var dragAndDrop = obj.GetComponent<DragAndDrop>();
        if (dragAndDrop != null)
        {
            dragAndDrop.enabled = draggable;
        }
    }
}
