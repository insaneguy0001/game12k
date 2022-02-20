using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
    public Pause pause;


    public void Quit()
    {
        Application.Quit();
    }

    public void DontQuit()
    {
        gameObject.SetActive(false);
        pause.IsQuiting = false;
    }

}
