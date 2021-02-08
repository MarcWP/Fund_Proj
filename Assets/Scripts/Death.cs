using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.onDeath += SceneChange;
    }

    // Update is called once per frame
    void SceneChange()
    {
        
    }
}
