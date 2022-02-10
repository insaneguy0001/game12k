using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator anim;
    public bool canattack;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (canattack)
            {
                anim.SetTrigger("Attack");
            }
            
            
        }
    }

    
}
