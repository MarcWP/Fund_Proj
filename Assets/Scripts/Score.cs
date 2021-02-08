using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static int scorePoints;
    private TextMeshProUGUI score;
    int coins;

    //Nos suscribimos al evento pickUp que se utiliza como señal para agregar puntos
    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        scorePoints = 0;
        GameEvent.current.onPickUp += addPoints;
        coins =GameObject.FindGameObjectsWithTag("coin").Length;
    }

    //Agregamos puntos al "marcador"
    private void addPoints()
    {
        scorePoints += 1;
        int uPoints = scorePoints % 10;
        int dPoints = (scorePoints - uPoints)/10;
        score.text="<sprite=" + dPoints +">"+ "<sprite="+ uPoints + ">";
        //si tenemos todas las monedas llamamos al evento para abrir la puerta 
        if (scorePoints==coins)
        {
            GameEvent.current.AllPicked();
        }
    }

}

