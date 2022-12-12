using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovinur : MonoBehaviour
{
    // Stilla breytur
    protected Animator anim;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Hoppað á óvininn
    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }

    // Drepa óvininn
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
