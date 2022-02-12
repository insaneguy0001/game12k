using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public Animator animator;
    float FireRate = 3f;
    float TimeToNextFire = 0f;
    public bool canShoot = true;


    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time >= TimeToNextFire)
        {
            if (canShoot)
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
