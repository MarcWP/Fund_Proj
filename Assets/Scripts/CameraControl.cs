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
    public GameObject cameraDummy;
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
            cameraDummy.transform.position = new Vector3(cameraDummy.transform.position.x+width, cameraDummy.transform.position.y, cameraDummy.transform.position.z);
        }
        else if(viewPortPos.x < 0)
        {
            cameraDummy.transform.position = new Vector3(cameraDummy.transform.position.x-width, cameraDummy.transform.position.y, cameraDummy.transform.position.z);
        }
        else if (viewPortPos.y >1f)
        {
            cameraDummy.transform.position = new Vector3(cameraDummy.transform.position.x, cameraDummy.transform.position.y + height, cameraDummy.transform.position.z);
        }
        else if (viewPortPos.y < 0f)
        {
            cameraDummy.transform.position = new Vector3(cameraDummy.transform.position.x, cameraDummy.transform.position.y - height, cameraDummy.transform.position.z);
        }

    }
}