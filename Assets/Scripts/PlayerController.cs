using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    public int cherries = 0;

    //Inspector variables
     [SerializeField]private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    //FSM
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
        Movement();
        AnimationState();
        anim.SetInteger("State", (int)state); //sets anitmation based on enuemrator state
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collectable")
        {
            Destroy(collision.gameObject);
            cherries += 1;
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

        }
        //Moving right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.Jumping;
        }
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
