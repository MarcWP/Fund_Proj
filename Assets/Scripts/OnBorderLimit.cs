using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBorderLimit : MonoBehaviour
{

    private float length;
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;

    //Suscripción al evento activado al moverse horizontalmente
    void Start()
    {
        GameEvent.current.onCamScroll += scroll;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Parallax -> scroll y reposicionamiento de sprites
    void scroll()
    {

        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;

    }
}
