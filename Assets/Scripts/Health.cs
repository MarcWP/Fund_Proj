using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int TotalHealth;
    public Slider slider;
    private Animator anim;

    //establecemos salud total y nos suscribimos al evento de daño
    void Start()
    {
        anim = GetComponent<Animator>();
        GameEvent.current.onTakeHit += substractHealth;
        GameEvent.current.onHeal += addHealth;
    }

    //En nuestro caso solo hay un enemigo, sin embargo, se puede argumentos para indicar diferentes magnitudes de daño
    private void substractHealth(GameObject x)
    {
        slider.value -= 1;
        anim.SetInteger("health", (int)slider.value);
    }

    private void addHealth()
    {
        slider.value += 1;
        anim.SetInteger("health", (int)slider.value);
    }


}
