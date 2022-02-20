using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{

    public TextMeshProUGUI FPStm;
    private float pollingTime = 1f;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.deltaTime;
        frameCount++;
        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FPStm.text = frameRate.ToString() + " FPS";
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
