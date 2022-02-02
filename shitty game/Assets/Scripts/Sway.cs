using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField] private float smoothSway = 8f;
    [SerializeField] private float multiplier = 2f;
    float x;
    float y;
    
  





    Vector3 direction;


    private void Update()
    {
        x = Input.GetAxisRaw("Mouse X") * multiplier;
        y = Input.GetAxisRaw("Mouse Y") * multiplier;

        
       
        Rotation();
        
    }
    void Rotation()
    {
        Quaternion rotX = Quaternion.AngleAxis(-y, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(x, Vector3.up);
        Quaternion finalRot = rotX * rotY;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRot, smoothSway * Time.deltaTime);
    }
    
    
}
