using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider Oxygenbar;
    private int maxOxygen = 100;
    private int currentOxygen;
    
  
    void Start()
    {
        currentOxygen = maxOxygen;
        Oxygenbar.maxValue = maxOxygen;
        Oxygenbar.value = maxOxygen;
    }
    public void UseOxygen(int amount)
    {
        if (currentOxygen - amount >= 0)
        {
            currentOxygen -= amount;
            Oxygenbar.value = currentOxygen;
        }
        else if (currentOxygen - amount <= 0)
        {
            Debug.Log(" not enough oxygen");
        }
    }

}
