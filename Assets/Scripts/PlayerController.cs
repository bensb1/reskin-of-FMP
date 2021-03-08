using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
     [SerializeField]private LayerMask ground;
    private enum State { idle,running,Jumping,falling}
    private State state = State.idle;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

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
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
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
