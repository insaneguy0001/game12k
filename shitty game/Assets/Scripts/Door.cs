using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool AreDoorsOpen = false;
    Animator anim;


    
    
    public void DoorsInteract()
    {
        anim = GetComponent<Animator>();
        
        anim.SetTrigger("OpenClose");
    }

    
    

    
}
