using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lava : MonoBehaviour
{
    private bool alreadyDamaged;

    public float speed = 5f;
    private void Awake()
    {
       alreadyDamaged = false; 
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!alreadyDamaged) { PermanenttUI.perm.health -= 1; alreadyDamaged = true; }
            PermanenttUI.perm.healthAmount.text = PermanenttUI.perm.health.ToString();


            PermanenttUI.perm.Reset();
            if (PermanenttUI.perm.health > 0)
            {
               
                if (SceneManager.GetActiveScene().name != "FirstLevel")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                
            }
            else if (PermanenttUI.perm.health <= 0)
            {
                SceneManager.LoadScene("FirstLevel");
                PermanenttUI.perm.health = 5;
            }
        }
    }
}
