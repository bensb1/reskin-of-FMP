using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lava : MonoBehaviour
{
    public float speed = 5f;
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
            PermanenttUI.perm.health -= 1;
            PermanenttUI.perm.healthAmount.text = PermanenttUI.perm.health.ToString();
           
            }
            PermanenttUI.perm.Reset();
        if (PermanenttUI.perm.health > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (PermanenttUI.perm.health <= 0)
            {
                SceneManager.LoadScene("first level");
                PermanenttUI.perm.health = 5;
            }
    }
}
