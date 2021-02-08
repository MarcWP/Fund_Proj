using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    private Vector3 viewPortPos;
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2 * cam.orthographicSize;
        width = height * cam.aspect;
    }

    private void OnBecameInvisible()
    {
        viewPortPos = cam.WorldToViewportPoint(transform.position);
        print(viewPortPos);


        if (viewPortPos.x > 1)
        {
            cam.transform.position = new Vector3(cam.transform.position.x+width, cam.transform.position.y, cam.transform.position.z);
        }
        else if(viewPortPos.x < 0)
        {
            cam.transform.position = new Vector3(cam.transform.position.x-width, cam.transform.position.y, cam.transform.position.z);
        }
        else if (viewPortPos.y >1f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + height, cam.transform.position.z);
        }
        else if (viewPortPos.y < 0f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - height, cam.transform.position.z);
        }

    }
}