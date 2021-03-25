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

    public static PermanenttUI perm;
    private void Start()
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
