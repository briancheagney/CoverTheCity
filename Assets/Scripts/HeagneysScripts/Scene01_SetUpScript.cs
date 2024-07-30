using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01_SetUpScript : MonoBehaviour
{

    public GameObject introPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowScene01Text()
    {
        Debug.Log("Scene 01 Intro Anim finished");
        // Your code to execute when the animation ends.
        introPanel.SetActive(true); // opens the intro panel once the animation finishes.
    }
}
