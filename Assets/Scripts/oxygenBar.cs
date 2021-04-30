using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oxygenBar : MonoBehaviour
{
    public Slider Oxygenbar;
    private int maxOxygen = 100;
    private int currentOxygen;
    public static oxygenBar instance;
    private void Awake()
    {
        instance = this;
    }

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
        else Debug.Log(" not enough oxygen");
    }


}
