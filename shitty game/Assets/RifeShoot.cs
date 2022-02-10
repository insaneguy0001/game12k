using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifeShoot : MonoBehaviour
{

    public bool canshoot;
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public float recoli = -30f;
    float FireRate = 10f;
    float TimeToNextFire = 0f;
    public Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= TimeToNextFire)
        {
            if (canshoot)
            {
                TimeToNextFire = Time.time + 1f / FireRate;
                Shoot();
            }

        }
    }




    void Shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            animator.SetTrigger("Shoot");
        }

        
    }


}
