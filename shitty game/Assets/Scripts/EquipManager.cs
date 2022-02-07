using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    
    [Header("Pistol")]
    public Gun gunScript;
    public GunShoot GunShootingScript;
    public GameObject GunObject;
    public Renderer SwordRenderer;
    int gunState = 1;
    int swordState = 1;
    float SavedFlashlight;
    float SavedDot;
    public Light RedDot;
    public Light flashLight;
    public Transform from;
    public Transform to;
    float speed = 1f;
    bool isNightVisionOn = false;
    public GameObject NightVision;
    public Sword swordScript;



    void Start()
    {
        gunScript.enabled = false;
        GunShootingScript.enabled = false;
        GunObject.SetActive(false);
        SwordRenderer.enabled = false;
        transform.rotation = from.rotation;
        swordScript.enabled = false;

    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            equipPistol();
        } else if (Input.GetKeyDown("2"))
        {
            equipSword();
        } else if (Input.GetKeyDown("n"))
        {
            if (isNightVisionOn)
            {
                NightVision.SetActive(false);
                isNightVisionOn = false;
            } else if (!isNightVisionOn)
            {
                NightVision.SetActive(true);
                isNightVisionOn = true;
            }
        }

    }

    //pistol

    void equipPistol()
    {
        if (gunState == 1)
        {

            showPistol();


        } else if (gunState == 0)
        {

            hideGun();

        }

    }
    void showPistol()
    {
        rotate();
        hideSword();
        gunScript.enabled = true;
        GunShootingScript.enabled = true;
        GunObject.SetActive(true);
        gunState = 0;
        

        if (SavedDot == 100)
        {
            RedDot.intensity = 100;
            gunScript.SetIsRedDotOn(true);
        }
        else if (SavedDot == 0)
        {
            RedDot.intensity = SavedDot;
            gunScript.SetIsRedDotOn(false);
        }

        if (SavedFlashlight == 1)
        {
            flashLight.intensity = SavedFlashlight;
            gunScript.SetIsLightOn(true);
        }
        else if (SavedFlashlight == 0)
        {
            flashLight.intensity = SavedFlashlight;
            gunScript.SetIsLightOn(false);
        }
    }

    void hideGun()
    {
        transform.rotation = from.rotation;
        gunScript.enabled = false;
        GunShootingScript.enabled = false;
        GunObject.SetActive(false);

        gunState = 1;
        SavedDot = RedDot.intensity;
        SavedFlashlight = flashLight.intensity;
        flashLight.intensity = 0;
        RedDot.intensity = 0;
        gunScript.SetIsLightOn(false);
        gunScript.SetIsRedDotOn(false);
    }


    //sword

    void equipSword()
    {
        if(swordState == 1)
        {
            showSword();
        }
        else if (swordState == 0)
        {

            hideSword();

        }

    }

    void showSword()
    {
        rotate();
        hideGun();
        swordState = 0;
        SwordRenderer.enabled = true;
        swordScript.enabled = true;
    }


    void hideSword()
    {
        swordState = 1;
        SwordRenderer.enabled = false;
        transform.rotation = from.rotation;
        swordScript.enabled = false;
    }


    void rotate()
    {
        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
    }

}
