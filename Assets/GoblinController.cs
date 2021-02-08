using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    private float distance;
    public Animator anim;
    public GameObject player;
    public float speed;
    private Vector3 startPos;
    private float dir;
    public float leftSide;
    public float rightSide;
    float side;
    private float disToPoint;
    private float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 3;
        distance = 100f;
        //anim = gameObject.GetComponent<Animator>();
        startPos = transform.position;
        side = 1;
        disToPoint = 100f;
        GameEvent.current.onAttack += hurt;
        GameEvent.current.onDestroy += Destroy;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        anim.SetFloat("distancia", distance);
        //pos = transform.position;
        anim.SetFloat("health", HP);
    }
    public void subHP()
    {
        HP -= 1;
    }
    void hurt(int id)
    {
        if(gameObject.GetInstanceID()==id)
            anim.SetBool("hurt", true);
    }
    public void seek()
    {
        dir=transform.position.x - player.transform.position.x;
        if (dir>0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,transform.position.y, 0), Time.deltaTime*speed);
    }


    public void wander()
    {
        disToPoint = Vector3.Distance(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(startPos.x + side, transform.position.y, 0));

        if (disToPoint<=0.1)
        {
            side = Random.Range(-leftSide, rightSide);
            if ((startPos.x + side)-transform.position.x < 0)
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            else if ((startPos.x + side) - transform.position.x > 0)
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("stop", true);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPos.x + side, transform.position.y, 0), Time.deltaTime * speed);
        }
    }

    private void Destroy(int id)
    {
        if (gameObject.GetInstanceID() == id)
        {
            Destroy(this.gameObject);
            GameEvent.current.onAttack -=hurt;
            GameEvent.current.onDestroy -= Destroy;
        }
            
    }
}
