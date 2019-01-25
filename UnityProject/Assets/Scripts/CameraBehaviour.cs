using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    /*
    private float x;
    private float y;
    private Vector3 targetRotation;
    private Vector3 rotateValue;
    private Quaternion rotation;

    void Start()
    {
        camera = this.transform.GetChild(0).transform;

        rotation = transform.rotation;
    }

    void Update()
    {
        x = Input.GetAxis("Mouse X");
        //y = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(x, 0, 0);
        targetRotation = transform.position + rotateValue;
        rotation = Quaternion.Euler(x, 0, 0);
        transform.rotation = rotation;
    }*/

    /*public Camera cam;          //Main camera for rotate in y-axis
    public float zoom;


    void Update()               //Updated every frame;
    {
        this.LookRotation(transform, cam.transform);    //Call LookRotation() to change the x-rotation of the gameobject and the y-rotation of camera

       /* if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (zoom + Input.GetAxis("Mouse ScrollWheel") > 0.5f && zoom + Input.GetAxis("Mouse ScrollWheel") < 2.0f)
            {
                zoom += Input.GetAxis("Mouse ScrollWheel");
            }
        }*/
    /*}

    public void LookRotation(Transform character, Transform camera)     //Change the x-rotation of the gameobject and the y-rotation of camera
    {
        float yRot = Input.GetAxis("Mouse X") * 2f;     //get x and y of mouse in screen
        float xRot = Input.GetAxis("Mouse Y") * 2f;
        character.localRotation *= Quaternion.Euler(0f, yRot, 0f);      //To change character's rotation around y-axis
        camera.localRotation *= Quaternion.Euler(-xRot, 0f, 0f);        //To change camera's rotation around x-axis
        camera.localRotation = ClampRotationAroundXAxis(camera.localRotation);  //Clamp camera's rotation
    }  
    //The key point is use localRotation,not rotation or Quaternion.Rotate.
    Quaternion ClampRotationAroundXAxis(Quaternion q)       //The method of clamp rotation,I can't understand it;use it carefully.
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -90f, 90f);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }*/
    public float speed;
    public float zoom;
    private Transform camera;

    private void Start()
    {
        camera = this.transform.GetChild(0).transform;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * 2, 0) + transform.localRotation.eulerAngles);

            //if (camera.localRotation.eulerAngles.x - Input.GetTouch(0).deltaPosition.y * speed * 12 * 0.5f < 90 && camera.localRotation.eulerAngles.x - Input.GetTouch(0).deltaPosition.y * speed * 12 * 0.5f > 0)
            /*if (camera.localRotation.eulerAngles.x - Input.GetAxis("Mouse X") * speed * 12 * 0.5f < 90 && camera.localRotation.eulerAngles.x - Input.GetAxis("Mouse X") * speed * 12 * 0.5f > 0)
            {
                camera.Translate(0, -Input.GetAxis("Mouse X") * (90 - camera.localRotation.x) * speed * 0.35f * 1 / zoom * 0.5f, -Input.GetAxis("Mouse X") * camera.localRotation.x * speed * 0.35f * 1 / zoom * 0.5f);
                camera.Rotate(-Input.GetAxis("Mouse X") * speed * 12 * 0.5f, 0, 0);
            }
            else if (camera.localRotation.eulerAngles.x - Input.GetAxis("Mouse X") * speed * 12 * 0.5f >= 90)
            {
                camera.localPosition = new Vector3(0, 150 * 1 / zoom, 0);
                camera.localRotation = Quaternion.Euler(90, 0, 0);
            }
            else if (camera.localRotation.eulerAngles.x - Input.GetAxis("Mouse X") * speed * 12 * 0.5f <= 0)
            {
                camera.localPosition = new Vector3(0, 0, -150 * 1 / zoom);
                camera.localRotation = Quaternion.Euler(0, 0, 0);
            }

        }
        /*else if (Input.touchCount == 2)
        {
            float distanceOfFingersLastFrame = Vector2.Distance(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition, Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);
            float distanceOfFingersThisFrame = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            if (zoom * 1 + ((float)distanceOfFingersThisFrame - (float)distanceOfFingersLastFrame) / 1000f < 2.0f && zoom * 1 + ((float)distanceOfFingersThisFrame - (float)distanceOfFingersLastFrame) / 1000f > 0.5f)
            {
                zoom *= 1 + ((float)distanceOfFingersThisFrame - (float)distanceOfFingersLastFrame) / 1000f;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (zoom + Input.GetAxis("Mouse ScrollWheel") > 0.5f && zoom + Input.GetAxis("Mouse ScrollWheel") < 2.0f)
            {
                zoom += Input.GetAxis("Mouse ScrollWheel");
            }
        }


        if (Vector3.Distance(camera.position, this.gameObject.transform.position) != 150 * 1 / zoom)
        {
            camera.Translate(0, 0, Vector3.Distance(camera.position, this.gameObject.transform.position) - 150 * 1 / zoom);
    */    
        }
    }
}

