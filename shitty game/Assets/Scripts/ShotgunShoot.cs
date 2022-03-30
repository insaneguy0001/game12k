using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public Animator animator;
    float FireRate = 1f;
    float TimeToNextFire = 0f;
    public bool canShoot = true;


    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time >= TimeToNextFire && canShoot)
        {
            TimeToNextFire = Time.time + 1f / FireRate;
            Shoot();

        }
    }
    void Shoot()
    {
        animator.SetTrigger("Shoot");
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

        }


    }
}
