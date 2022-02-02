using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHp = 100;
    public int CurrentHp;
    public HealthBar healthBar;

    void Start()
    {
        CurrentHp = MaxHp;
        healthBar.MaxHealth(MaxHp);
    }



    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            Damage(20);
        }
    }


    void Damage(int damage)
    {
        CurrentHp -= damage;
        healthBar.HealthSlider(CurrentHp);
    }
}
