using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideStats : MonoBehaviour
{
    public GameObject Stats;

    void Start()
    {
        Stats.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F3))
        {
            Stats.SetActive(true);
        }
        else
        {
            Stats.SetActive(false);
        }
    }
}
