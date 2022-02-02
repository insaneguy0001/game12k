using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{

    public Camera cam;
    public float range = 3f;
    
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            InteractWithDoor();
        }

        void InteractWithDoor()
        {
            RaycastHit hit;

            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Door door = hit.transform.GetComponent<Door>();
                if(door != null)
                {
                    door.DoorsInteract();
                }
            }


        }
    }
}
