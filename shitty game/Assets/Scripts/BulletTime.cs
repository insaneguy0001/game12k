using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    Animator _animator;
    bool bullettime;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            if (bullettime)
            {
                bullettime = false;
                _animator.SetInteger("bullettime", 0);
                Time.timeScale = 1f;
            }
            else if (!bullettime)
            {
                bullettime = true;
                _animator.SetInteger("bullettime", 1);
                Time.timeScale = 0.1f;
            }

        }
        
    }
}
