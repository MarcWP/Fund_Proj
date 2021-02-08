using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GameEvent.current.onPlayerAction+=close;
        GameEvent.current.onAllPicked += closeLastDoor;
    }

    // Update is called once per frame
    void close(int id)
    {
        if(id==gameObject.GetInstanceID())
            anim.SetBool("cerrar", true);
    }
    void closeLastDoor()
    {
        anim.SetBool("cerrar", true);

    }

    
    private void OnDestroy()
    {
        GameEvent.current.onPlayerAction -= close;
        GameEvent.current.onAllPicked -= closeLastDoor;
    }
}
