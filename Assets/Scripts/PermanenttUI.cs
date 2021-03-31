using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PermanenttUI : MonoBehaviour
{
    //player stats
    public int cherries = 0;
   public int health;
     public  Text healthAmount;
    public  TextMeshProUGUI cherriesText;
    public int coins = 0;
    public TextMeshProUGUI coinsText;

    public static PermanenttUI perm;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        //singleton
        if(!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        cherries = 0;
        cherriesText.text = cherries.ToString();
    }
}
