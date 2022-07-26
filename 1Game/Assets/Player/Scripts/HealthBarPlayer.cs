using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int maxhealth)
    {

        slider.maxValue = maxhealth;
        slider.value = maxhealth;

    }
    public void SetHealth(int currenthealth)
    {
        slider.value = currenthealth;

    }

    public void Healthbarhealing(int healingpot, float currenthealth)
    {

        slider.value = currenthealth + healingpot;

    }

    public void SetMaxHealthForShop(int maxhealth)
    {

        slider.maxValue = maxhealth;
        

    }
}
