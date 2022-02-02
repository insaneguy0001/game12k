using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPos : MonoBehaviour
{
    public GameObject NormalPos;
    public GameObject AimPos;
    public bool paused = false;

    void Start()
    {
        transform.position = NormalPos.transform.position;
    }

    void Update()
    {
        if (!paused)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                transform.position = Vector3.Lerp(transform.position, AimPos.transform.position, 10f * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, NormalPos.transform.position, 10f * Time.deltaTime);
            }
        }
        
    }
}
