using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State { idle,running,Jumping}
    private State state = State.idle;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale =  new Vector2(-1, 1);
            
        }
         else if (hDirection > 0)
            {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            
            }
         else
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
            {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            state = State.Jumping;
            }
        VelocityState();
        anim.SetInteger("State", (int)state);
    }
    private void VelocityState()
    { if(state == State.Jumping)
        {

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
}
