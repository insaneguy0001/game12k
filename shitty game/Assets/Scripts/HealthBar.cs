using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image FillImage;
    public Gradient gradient;


    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        FillImage.color = gradient.Evaluate(1f);
    }

    public void HealthSlider(int health)
    {
        slider.value = health;
        
        //normalizedValue (od 0 do 1)
        FillImage.color = gradient.Evaluate(slider.normalizedValue);


    }
}
