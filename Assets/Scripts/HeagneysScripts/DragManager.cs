using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDragManager : MonoBehaviour
{
    public GameObject ddogDish;
    public GameObject ddogFood;
    public GameObject dblanket;

    private int currentDragIndex = 0;

    private void Start()
    {
        // Enable only the dog dish at the start
        SetDraggable(ddogDish, true);
        SetDraggable(ddogFood, false);
        SetDraggable(dblanket, false);
    }

    public void OnObjectPlaced(string objectName)
    {
        if (objectName == ddogDish.name && currentDragIndex == 0)
        {
            currentDragIndex++;
            SetDraggable(ddogFood, true);
        }
        else if (objectName == ddogFood.name && currentDragIndex == 1)
        {
            currentDragIndex++;
            SetDraggable(dblanket, true);
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
