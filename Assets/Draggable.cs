using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour{
    private bool dragging = false;
    private Vector3 offset;

    void Start() {
    }
    // Update is called once per frame
    void Update(){
        if (dragging) {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown(){
        // Record the difference between the objects centre, and the clicked poit on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp(){
        // stop dragging
        dragging = false;

    }
}
