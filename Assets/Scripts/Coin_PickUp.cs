using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_PickUp : MonoBehaviour
{
    Animator anim;
    bool stop;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        stop = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player" &&!stop)
        {
            stop = true;
            anim.SetBool("pickUp",true);
            GameEvent.current.pickUp();
        }
        
    }
}
