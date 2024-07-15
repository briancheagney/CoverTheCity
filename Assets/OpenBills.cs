using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBills : MonoBehaviour
{
    [SerializeField] GameObject ScollView;

    public void Open()
    {
        ScollView.SetActive(true);
    }

    public void Close()
    {
        ScollView.SetActive(false);
    }
}
