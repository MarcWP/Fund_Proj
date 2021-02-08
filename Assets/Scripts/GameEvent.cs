using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;

    private void Awake()
    {
        current = this;
    }
    //Aqui empiezan los eventos

    //Evento lever para la palanca
    public event Action<int> onPlayerAction;

    public void PlayerAction(int x)
    {
        if (onPlayerAction != null)
        {
            onPlayerAction(x);
        }
    }

    //Evento pickUp para cuando se recoge un objeto
    public event Action onPickUp;

    public void pickUp()
    {
        if (onPickUp != null)
        {
            onPickUp();
        }
    }


    //Evento TakeHit para cuando se recibe daño
    public event Action<int> onAttack;

    public void Attack(int id)
    {
        if (onAttack != null)
        {
            onAttack(id);
        }
    }


    //Evento TakeHit para cuando se recibe daño
    public event Action<GameObject> onTakeHit;

    public void takeHit(GameObject x)
    {
        if (onTakeHit != null)
        {
            onTakeHit(x);
        }
    }

    public event Action onSC;
    public void SC()
    {
        onSC?.Invoke();
    }


    //Evento muerte, en caso de que la partida deba llegar a su fin, ya sea por vida=0 u otras causas
    public event Action onDeath;

    public void death()
    {
        if (onDeath != null)
        {
            onDeath();
        }
    }

    //Evento CamScroll para el scroll de fondo cuando se mueve el personaje
    public event Action onCamScroll;

    public void camScroll()
    {
        if (onCamScroll != null)
        {
            onCamScroll();
        }
    }


    //Efecto take back to pool en caso de requerir devolver un objeto a su estado inactivo en la pool
    public event Action onHeal;

    public void Heal()
    {
        if (onHeal != null)
        {
            onHeal();
        }
    }

    public event Action<int> onPause;
    public void Pause(int i)
    {
        onPause?.Invoke(i);
    }

    public event Action<int> onDestroy;

    public void Destroy(int id)
    {
        if (onDestroy != null)
        {
            onDestroy(id);
        }
    }

    public event Action onAllPicked;

    public void AllPicked()
    {
        if (onAllPicked != null)
        {
            onAllPicked();
        }
    }


}
