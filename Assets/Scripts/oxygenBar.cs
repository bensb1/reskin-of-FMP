using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            if (PermanenttUI.perm.health > 0)
                PermanenttUI.perm.health -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            OxygenReset();
               if (PermanenttUI.perm.health <= 0 )
            {
                SceneManager.LoadScene("FirstLevel");
                PermanenttUI.perm.health = 5;
            }



        }
 
    }

    internal void ResetOxygen()
    {
        slider.value = maxOxygen;
    }
}
