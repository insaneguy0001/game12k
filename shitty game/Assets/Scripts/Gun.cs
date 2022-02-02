using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Light flashLight;
    bool isLightOn;
    public Light RedDot;
    bool isRedDotOn;

    private void Start()
    {
        isLightOn = false;
        isRedDotOn = false;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown("f"))
        {
            if (isLightOn)
            {
                flashLight.intensity = 0;
                isLightOn = false;
            }
            else if (!isLightOn)
            {
                flashLight.intensity = 1;
                isLightOn = true;
            }
        }
        if (Input.GetKeyDown("r"))
        {
            if (isRedDotOn)
            {
                RedDot.intensity = 0;
                isRedDotOn = false;
            }
            else if (!isRedDotOn)
            {
                RedDot.intensity = 100;
                isRedDotOn = true;
            }
        }
    }


    public void SetIsLightOn(bool lightbool)
    {
        isLightOn = lightbool;
    }

    public void SetIsRedDotOn(bool dotbool)
    {
        isRedDotOn = dotbool;
    }

}
