using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{

    [Header("Pistol")]

    public ShotgunShoot ShotgunScript;
    public RifeShoot rifeScript;
    public GunShoot GunShootingScript;
    public Renderer GunObject1;
    public Renderer GunObject1_2;
    public Renderer GunObject1_3;
    public Renderer GunObject1_4;
    public Renderer SwordRenderer;
    int gunState = 1;
    int swordState = 1;
    int rife1state = 1;
    int shotgun1state = 1;
    public Transform from;
    public Transform to;
    float speed = 1f;
    bool isNightVisionOn = false;
    public GameObject NightVision;
    public Sword swordScript;
    public Renderer rife1;
    public Renderer shotgun1_1;
    public Renderer shotgun1_2;
    Quaternion startRot;
    Vector3 startPos;

    void Awake()
    {
        startRot = rife1.transform.rotation;
        startPos = rife1.transform.position;
    }


    void Start()
    {
        rifeScript.enabled = false;
        GunShootingScript.enabled = false;
        ShotgunScript.enabled = false;
        GunObject1.enabled = false;
        GunObject1_2.enabled = false;
        GunObject1_3.enabled = false;
        GunObject1_4.enabled = false;
        SwordRenderer.enabled = false;
        transform.rotation = from.rotation;
        swordScript.enabled = false;
        rife1.enabled = false;
        shotgun1_1.enabled = false;
        shotgun1_2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            equipPistol();
        }
        else if (Input.GetKeyDown("2"))
        {
            equipSword();
        }
        else if (Input.GetKeyDown("n"))
        {
            if (isNightVisionOn)
            {
                NightVision.SetActive(false);
                isNightVisionOn = false;
            }
            else if (!isNightVisionOn)
            {
                NightVision.SetActive(true);
                isNightVisionOn = true;
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            equipRife1();
        }
        else if (Input.GetKeyDown("4"))
        {
            equipShotgun();
        }

    }

    //pistol

    void equipPistol()
    {
        if (gunState == 1)
        {

            showPistol();


        }
        else if (gunState == 0)
        {

            hideGun();

        }

    }
    void showPistol()
    {
        rotate();
        hideSword();
        HideRife();
        HideShotgun();

        GunShootingScript.enabled = true;
        GunObject1.enabled = true;
        GunObject1_2.enabled = true;
        GunObject1_3.enabled = true;
        GunObject1_4.enabled = true;
        gunState = 0;



    }

    void hideGun()
    {
        transform.rotation = from.rotation;

        GunShootingScript.enabled = false;
        GunObject1.enabled = false;
        GunObject1_2.enabled = false;
        GunObject1_3.enabled = false;
        GunObject1_4.enabled = false;
        gunState = 1;

    }


    //sword

    void equipSword()
    {
        if (swordState == 1)
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
        HideShotgun();
        HideRife();
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



    void equipRife1()
    {
        if (rife1state == 1)
        {
            ShowRife();
        }
        else if (rife1state == 0)
        {
            HideRife();
        }
    }


    void ShowRife()
    {
        rotate();
        hideGun();
        hideSword();
        HideShotgun();
        rife1state = 0;
        rife1.enabled = true;
        rifeScript.enabled = true;


    }

    void HideRife()
    {
        rife1.enabled = false;
        rife1state = 1;
        rifeScript.enabled = false;
    }


    void equipShotgun()
    {
        if (shotgun1state == 1)
        {
            showShotgun();
        }
        else if (shotgun1state == 0)
        {
            HideShotgun();
        }
    }



    void showShotgun()
    {
        rotate();
        hideGun();
        hideSword();
        HideRife();
        shotgun1state = 0;
        shotgun1_1.enabled = true;
        shotgun1_2.enabled = true;
        ShotgunScript.enabled = true;
    }

    void HideShotgun()
    {
        shotgun1state = 1;
        shotgun1_1.enabled = false;
        shotgun1_2.enabled = false;
        ShotgunScript.enabled = false;
    }






    void rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, to.rotation, Time.time * speed);
    }

}



    

    
    

    

