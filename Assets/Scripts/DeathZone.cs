using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //Simple zona de muerte por colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
            GameEvent.current.death();
        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "suelo")
            GameEvent.current.Destroy(collision.gameObject.GetInstanceID());
    }
}
