using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public DragAndDrop dogBowl;
    public DragAndDrop dogFood;
    public DragAndDrop blanket;

    private void Start()
    {
        // Disable all draggable scripts initially
        SetDraggable(dogBowl, false);
        SetDraggable(dogFood, false);
        SetDraggable(blanket, false);
    }

    public void EnableDogBowl()
    {
        SetDraggable(dogBowl, true);
    }

    public void EnableDogFood()
    {
        SetDraggable(dogFood, true);
    }

    public void EnableBlanket()
    {
        SetDraggable(blanket, true);
    }

    private void SetDraggable(DragAndDrop dragAndDrop, bool draggable)
    {
        if (dragAndDrop != null)
        {
            dragAndDrop.enabled = draggable;
        }
    }
}
