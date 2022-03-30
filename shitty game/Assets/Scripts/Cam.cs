using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private float sensitivityX = 100f;
    [SerializeField] private float sensitivityY = 100f;
    [SerializeField] Transform Orientation;
    Cam Instance;
    [SerializeField] Transform cam;
    [SerializeField] WallRunning wallrun;
    float x;
    float y;
    float multiplayer = 0.01f;
    float xRot;
    float yRot;
    public bool paused = false;

    private void Start()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (!paused)
        {
            InputSystem();
            cam.transform.rotation = Quaternion.Euler(xRot, yRot, wallrun.tilt);
            Orientation.transform.rotation = Quaternion.Euler(0, yRot, 0);
        }
        


    }
    void InputSystem()
    {
        x = Input.GetAxisRaw("Mouse X");
        y = Input.GetAxisRaw("Mouse Y");
        yRot += x * sensitivityX * multiplayer;
        xRot -= y * sensitivityY * multiplayer;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
    }
}
