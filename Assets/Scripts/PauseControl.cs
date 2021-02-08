using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.onPause += pause;
    }

    // Update is called once per frame
    void pause(int control)
    {
        if (control==1)
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            
        }
        else
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
}
