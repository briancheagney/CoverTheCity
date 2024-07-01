using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour{
    private bool dragging = false;
    private Vector3 offset;
    private bool overlapping = false;

    void Start() {
    }
    // Update is called once per frame
    void Update(){
       
        if (dragging) {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            if (overlapping)
            {

            }
        }
    }
    private void OnMouseDown(){
        // Record the difference between the objects centre, and the clicked point on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp(){
        // stop dragging
        dragging = false;

    }
}
