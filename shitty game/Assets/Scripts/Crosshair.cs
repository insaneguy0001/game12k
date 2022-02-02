using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    public GameObject crosshair;

    void Start()
    {
        gameObject.SetActive(true);
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            crosshair.gameObject.SetActive(false);
        }
        else
        {
            crosshair.gameObject.SetActive(true);
        }
    }
}
