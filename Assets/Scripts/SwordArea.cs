using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArea : MonoBehaviour
{
    //Simple control de colisiones con el arma para ataques
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameEvent.current.Attack(collision.gameObject.GetInstanceID());
            }
        }
    }
}
