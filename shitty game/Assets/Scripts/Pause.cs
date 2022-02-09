using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool isPauseOpen = false;
    public GameObject PauseUI;
    public GameObject player;
    public GunShoot ShootingScript;
    public Movement movementScript;
    
    public AudioSource FootSteps;
    Cam cam;


    void Start()
    {
        cam = player.GetComponent<Cam>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseOpen)
            {
                resume();
            }else if (!isPauseOpen)
            {
                pause();
            }
        }


        

    }
    
    
    public void resume()
    {
        
        PauseUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPauseOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam.paused = false;
        ShootingScript.canShoot = true;
        FootSteps.enabled = true;
        movementScript.paused = false;
        
    }

    public void pause()
    {
        
        PauseUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPauseOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cam.paused = true;
        ShootingScript.canShoot = false;
        FootSteps.enabled = false;
        movementScript.paused = true;
        

    }

    public void quit()
    {
        Application.Quit();
    }


}
