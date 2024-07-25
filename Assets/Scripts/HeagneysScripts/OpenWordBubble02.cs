using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWordBubble02 : MonoBehaviour
{
    public GameObject textBubble02;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnScaleDownAndMoveAnimationEnd()
    {
        Debug.Log("Animation finished!");
        // Your code to execute when the animation ends.
        textBubble02.SetActive(true); // opens the second bubble once the animation finishes.
    }
}
