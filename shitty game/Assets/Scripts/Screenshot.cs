using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{

    int superSize = 2;
    private int _shotIndex = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ScreenCapture.CaptureScreenshot($"Screenshot{_shotIndex}.png", superSize);
            _shotIndex++;
        }
    }



    
}
