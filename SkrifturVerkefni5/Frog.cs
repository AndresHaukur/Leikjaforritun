using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Ovinur
{
    // Stilla breytur
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;

    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Transition frá Jumping í Falling
        if(anim.GetBool("Jumping"))
        {
            if(rb.velocity.y < .1f)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }
        // Transition frá Falling í Idle
        if(coll.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);
        }
    }

    private void Move()
    {
        if(facingLeft)
        {
            if(transform.position.x > leftCap)
            {
                // Testa hvaða átt froskurinn er að snúa
                if(transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                // testa hvort froskurinn er að snerta jörðina
                if(coll.IsTouchingLayers(ground))
                {
                    // ef hann er að snerta jörðina, hoppa
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }

        else
        {
            if(transform.position.x < rightCap)
            {
                // Testa hvaða átt froskurinn er að snúa
                if(transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }


                // testa hvort froskurinn er að snerta jörðina
                if(coll.IsTouchingLayers(ground))
                {
                    // ef hann er að snerta jörðina, hoppa
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }    
}
