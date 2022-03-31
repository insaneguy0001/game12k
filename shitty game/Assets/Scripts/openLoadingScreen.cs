using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class openLoadingScreen : MonoBehaviour
{
    int number;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OpenScene()
    {
        number = Random.Range(1, 50);
        if(number == 2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
