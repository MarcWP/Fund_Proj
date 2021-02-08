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

    // Cerrar instancias de puertas en función de su id
    void close(int id)
    {
        if(id==gameObject.GetInstanceID())
            anim.SetBool("cerrar", true);
    }
    //En caso de recolectar todas las monedas
    void closeLastDoor()
    {
        anim.SetBool("cerrar", true);

    }

    //Desubscribimos
    private void OnDestroy()
    {
        GameEvent.current.onPlayerAction -= close;
        GameEvent.current.onAllPicked -= closeLastDoor;
    }
}
