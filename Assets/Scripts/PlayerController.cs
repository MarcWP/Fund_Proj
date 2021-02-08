using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public bool grounded;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRend;
    private Animator animator;
    public GameObject swordHilt;
    

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        grounded = true;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameEvent.current.onTakeHit += Hurt;
    }

    void Update()
    {
        animator.SetFloat("YVelocity",rigidbody2d.velocity.y);
        //Controles del jugador

        //Acción atacar
        if (Input.GetMouseButtonDown(0))
        {
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                animator.SetBool("atacar", true);
            }
            else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                swordHilt.GetComponent<Animator>().SetBool("atacar", true);
            }
            
        }
        //Moverse a la izquierda y flip a sprites
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            spriteRend.flipX=true;
            swordHilt.GetComponent<SpriteRenderer>().flipX = true;
            swordHilt.transform.position =new Vector3(transform.position.x-0.7f, transform.position.y, 0);
            animator.SetBool("correr", true);
        }

        //Moverse a la derecha y flip a sprites
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            spriteRend.flipX = false;
            swordHilt.GetComponent<SpriteRenderer>().flipX = false;
            swordHilt.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, 0);
            animator.SetBool("correr", true);
        }

        //Parar
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("correr", false);
        }
        
        //La propiedad grounded se gestiona en los "pies" del jugador
        if (grounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigidbody2d.velocity = Vector2.up * jumpSpeed;
                grounded = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameEvent.current.Pause(0);
        }
        

    }

    void Hurt(GameObject monster)
    {   
        float dir = monster.transform.position.x - transform.position.x;
        Rigidbody2D prb = GetComponent<Rigidbody2D>();
        if (dir > 0)
        {
            prb.AddForce(prb.transform.right * -1600);
            prb.AddForce(prb.transform.up * 1600);
        }
        else
        {
            prb.AddForce(prb.transform.right * 1600);
            prb.AddForce(prb.transform.up * 1600);
        }
        animator.SetBool("dañado", true);
    }



}