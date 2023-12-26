using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;//从最大的开始
        slider.value = health;
    }
    public void setHealthBar(float health)
    {
        slider.value = health;
    }
    
}
