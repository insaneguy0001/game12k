using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resDropdown;
    public Transform Right;
    public Transform Left;
    public Transform Center;
    public Transform Guns;
    public Transform RotRef;
    public GameObject gunContainer;
    public Camera mainCam;
    public Camera WeaponCam;
    public GameObject rawImage;
    public RenderTexture renderTexture;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }



        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();

    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    
    


    public void gunPosition(int WeaponPosIndex)
    {
        if(WeaponPosIndex == 0)
        {
            gunContainer.transform.position = Right.position;
            Debug.Log("GunContainer position changed");
        }
        else if(WeaponPosIndex == 1)
        {
            gunContainer.transform.position = Left.position;
            Debug.Log("GunContainer position changed");
        }
        else if (WeaponPosIndex == 2)
        {
            gunContainer.transform.position = Center.position;
            Debug.Log("GunContainer position changed");
        }
    }


    public void Pixelated(bool pixelated)
    {
        if (pixelated)
        {
            mainCam.targetTexture = renderTexture;
            WeaponCam.targetTexture = renderTexture;
            rawImage.SetActive(true);
        } 
        else if (!pixelated)
        {
            mainCam.targetTexture = null;
            WeaponCam.targetTexture = null;
            rawImage.SetActive(false);
        }
    }


    public void vSync(bool vSyncOn)
    {
        if (vSyncOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

}
