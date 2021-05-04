using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    
    

    //Inspector variables
     [SerializeField]private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    
    
    [SerializeField] private float hurtForce = 10f;
    
    [SerializeField]private AudioSource footstep;
    [SerializeField] private int health;
    [SerializeField] private Text healthAmount;
    [SerializeField] private int coins = 0;
    private float timer = 0f;
    private float waitTimer =2f;
    //FSM
    private enum State { idle,running,Jumping,falling, hurt}
    private State state = State.idle;
    private OxygenBar oxygenBar;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
         PermanenttUI.perm.healthAmount.text = PermanenttUI.perm.health.ToString();
        oxygenBar = GetComponent<OxygenBar>();
        
        

    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (state != State.hurt)
        {
            Movement();
        }
        
        AnimationState();
        anim.SetInteger("State", (int)state); //sets animation based on enuemrator state
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collectable")
        {
            
            Destroy(collision.gameObject);
            

            coins += 1;
            PermanenttUI.perm.coins += 1;
            PermanenttUI.perm.coinsText.text = PermanenttUI.perm.coins.ToString();
        }
        if(collision.tag =="PowerUp")
        {
            Destroy(collision.gameObject);
            jumpForce = 17.5f;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(resetPower());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
          
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (state == State.falling)
            {
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                state = State.hurt;
                HandleHealth(); //deals with health and updates ui and reset if player dies
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //enemy is to my right therfore i should be damaged and move left
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    //enemy is to my Left therefore i should be damaged and move right
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }

        }
    }

    private void HandleHealth()
    {
        PermanenttUI.perm.health -= 1;
        PermanenttUI.perm.healthAmount.text = PermanenttUI.perm.health.ToString();
        if (PermanenttUI.perm.health <= 0)
        {
            SceneManager.LoadScene("first level");
            PermanenttUI.perm.health = 5;
        }
    }

    private void Movement()
    {
        //Moving left
        float hDirection = Input.GetAxis("Horizontal");


       
       
        
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            if (timer > waitTimer)
            {
                Debug.Log(timer);
                oxygenBar.UseOxygen(1);
                timer = 0;
            }

        }
        //Moving right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            if (timer > waitTimer)
            {

                
                oxygenBar.UseOxygen(1);
                timer = 0;
            }

        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }
        
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.Jumping;
    }
    private void AnimationState()
    { if(state == State.Jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
     else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
    else if(state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
         else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }
    else
        {
            state = State.idle;
        }
    
    }
    private void Footstep()
    {
        footstep.Play();
    }
    private IEnumerator resetPower()
    {
        yield return new WaitForSeconds(10);
        jumpForce = 10;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}

