using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerC : MonoBehaviour
{
    // Stilla breyta sem heldur utan um hraðann á leikmanninum
    private Rigidbody2D rb;
    // Stilla breyta sem heldur utan um Animator component-ið
    private Animator anim;
    // Stilla state breytu sem heldur utan um hvernig leikmaðurinn er að hreyfast
    private enum State {idle, running, jumping, falling, hurt};
    // Stilla breytu sem heldur utan um hvernig leikmaðurinn er að hreyfast
    private State state = State.idle;
    // Stilla breytu sem heldur utan um Collider component-ið
    private Collider2D coll;
    // Breyta sem segir hvort player er að snerta jörðina
    [SerializeField] private LayerMask ground;
    // Breyta sem heldur utan um hraðann á leikmanninum
    [SerializeField] private float speed = 5f;
    // Breyta sem heldur utan um hoppstyrk leikmannsins
    [SerializeField] private float jumpForce = 10f;
    // Breyta sem heldur utan um fjölda kirsuberja
    [SerializeField] private int cherries = 0;
    // Breyta sem heldur utan um textann sem birtir fjölda kirsuberja
    [SerializeField] private Text cherryText;
    // Breyta sem segir hversu mikið þú færist til þegar þú meiðist
    [SerializeField] private float hurtForce = 10f;
    // Breyta sem heldur utan um líf leikmannsins
    [SerializeField] private int health;
    // Breyta sem heldur utan um textann sem birtir líf leikmannsins
    [SerializeField] private Text healthAmount;


    private void Start()
    {
        // Ná í Rigidbody component-ið
        rb = GetComponent<Rigidbody2D>();
        // Ná í Animator component-ið
        anim = GetComponent<Animator>();
        // Ná í Collider component-ið
        coll = GetComponent<Collider2D>();
        // Birta fjölda kirsuberja
        healthAmount.text = health.ToString();
    }

    private void Update()
    {
        // hreyfir kallin ef hann er ekki særður state
        if(state != State.hurt)
        {
            Movement();
        }
        // Kalla á Movement fallið
        Movement();
        // Kalla á StateSwitch fallið
        StateSwitch();
        // Kalla á AnimationState fallið
        anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ef leikmaðurinn snertir kirsuberju
        if(collision.tag == "Collectable")
        {
            // Eyða kirsuberjunni
            Destroy(collision.gameObject);
            // Bæta við einum í breytuna cherries
            cherries += 1;
            // Birta fjölda kirsuberja
            cherryText.text = cherries.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            // Ná í Enemy script-ið
            Ovinur ovinur = other.gameObject.GetComponent<Ovinur>();
            // Ef leikmaðurinn er að detta niður
            if(state == State.falling)
            {
                ovinur.JumpedOn();
                Jump();
            }
            else
            {   
                state = State.hurt;
                HandleHealth(); // updatear það sem kemur á skjáinn mepað við líf leikmannsins
                
                if(other.gameObject.transform.position.x > transform.position.x)
                {
                    // óvinur er hægra megin sem þýðir að ég taki skaða og hreyfist til vinstri
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    // óvinur er vinstra megin sem þýðir að ég taki skaða og hreyfist til hægri
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
        }
    }

    private void HandleHealth()
    {
        health -= 1;
        healthAmount.text = health.ToString();
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Movement()
    {
       // Ná í hnit leikmannsins
        float hDirection = Input.GetAxis("Horizontal");

        // Ef ýtt er á A takkann á lyklaborðinu þá fer leikmanninn til vinstri
        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        // Ef ýtt er á D takkann á lyklaborðinu þá fer leikmanninn til hægri
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        // Ef ýtt er á Space takkann á lyklaborðinu þá hoppar leikmaðurinn upp
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        } 
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        state = State.jumping;
    }

    // Fall sem skiptir um state leikmannsins
    private void StateSwitch()
    {
        // Ef leikmapðurinn er í loftinu
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {   
                state = State.falling;
            }
        }
        // Ef leikmaðurinn er að fara niður 
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        // Ef leikmaðurinn er særður
        else if(state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        // Ef leikmaðurinn er að hreyfast
        else if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            // Hreyfandi
            state = State.running;
        }
        else
        {
            // Idle
            state = State.idle;
        } 
    }
}