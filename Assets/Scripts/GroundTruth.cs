using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTruth : MonoBehaviour
{

    //Si entramos en contacto con el terreno, marcamos la propiedad "grounded" para indicar que se puede saltar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            //La propiedad grounded corresponde al objeto jugador padre de los pies
            GetComponentInParent<PlayerController>().grounded = true;
        }
    }


    //Al abandonar el suelo, desmarcamos la propiedad para no poder saltar en el aire
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            GetComponentInParent<PlayerController>().grounded = false;
        }
    }
}
