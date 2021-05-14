using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider;
    private int maxOxygen = 100;
    private int currentOxygen;
    
  
  void Start()
    {
        currentOxygen = maxOxygen;
        slider.maxValue = maxOxygen;
        slider.value = maxOxygen;

    }

    public void OxygenReset()
    {
        
        currentOxygen = maxOxygen;
        slider.maxValue = maxOxygen;
        slider.value = maxOxygen;
        


    }


    public void UseOxygen(int amount)
    {
        if (currentOxygen - amount >= 0)
        {
            currentOxygen -= amount;
            slider.value = currentOxygen;
        }
        else if (currentOxygen - amount <= 0)
        {
            Debug.Log(" not enough oxygen");
        }
      
    }

    internal void ResetOxygen()
    {
        slider.value = maxOxygen;
    }
}
