using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBackManager : MonoBehaviour
{
    public GameObject popupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi you ran this UI!");
        Instantiate(popupPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCloseButtonClick()
    {
        Instantiate(popupPrefab);
    }

    public void openPopup()
    {
        Instantiate(popupPrefab);
    }
}
