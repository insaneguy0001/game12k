using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIshowhide : MonoBehaviour
{

    public GameObject crosshair;
    public GameObject healthbar;

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            healthbar.SetActive(false);
            crosshair.SetActive(false);
        }
        else
        {
            healthbar.SetActive(true);
            crosshair.SetActive(true);
        }
    }
}
