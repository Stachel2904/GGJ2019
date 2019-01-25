using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    
    float speed = 10;
    float zoom = 0;
    private Transform camera;

    private void Start()
    {
        camera = this.transform.GetChild(0).transform;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * 3, 0) + transform.rotation.eulerAngles);
            
        }
        /*if (Input.GetAxis("Mouse Y") != 0)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler((new Vector3(Input.GetAxis("Mouse Y") * 3, 0, 0) + transform.rotation.eulerAngles);

        }*/
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                zoom += Input.GetAxis("Mouse ScrollWheel") * speed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                zoom += Input.GetAxis("Mouse ScrollWheel") * speed;
            }

            if (zoom >= -50 && zoom <= 3)
            {
                transform.GetChild(0).Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * speed);
            }
            
            if (zoom < -50)
            {
                zoom = -50;
            }

            if (zoom > 3)
            {
                zoom = 3;
            }
            
        }
        

    }
}

