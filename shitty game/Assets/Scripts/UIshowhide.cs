using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIshowhide : MonoBehaviour
{

    public GameObject UI;

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
    }
}
