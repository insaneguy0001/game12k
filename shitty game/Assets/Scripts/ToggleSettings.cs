using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettings : MonoBehaviour
{
    public GameObject pause;
    public GameObject settings;
    public Pause pauseScript;

    public void ShowSettings()
    {
        settings.SetActive(true);
        pause.SetActive(false);
        pauseScript.AreSettingsOn = true;
    }

    public void HideSettings()
    {
        settings.SetActive(false);
        pause.SetActive(true);
        pauseScript.AreSettingsOn = false;
    }
}
