using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBGLoop : MonoBehaviour
{
    public Vector3 ini;
    public GameObject player;
    public GameObject fondo;
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        //nos subscribimos al evento de movimiento   
        ini = gameObject.transform.position;
        size = fondo.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Si nos salimos del fondo, movemos la pantalla en consecuencia
    private void Update()
    {
        //Debemos tener en cuenta si nos salimos por la derecha o la izquierda
        if (player.transform.position.x> (fondo.transform.position.x+size/2))
            transform.position = new Vector3(transform.position.x+ size, 0, -10);
        else if (player.transform.position.x < (fondo.transform.position.x - size / 2))
            transform.position = new Vector3(transform.position.x - size, 0, -10);

    }


}
