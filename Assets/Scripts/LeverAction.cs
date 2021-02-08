using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
    public GameObject goID;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player" && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GameEvent.current.PlayerAction(goID.GetInstanceID());
        }
    }
}
