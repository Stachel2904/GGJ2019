using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject cam;
    public float speed = 50f;
    public float maxSpeed;
    public float autoBrake;
    //public float factor;

    private Rigidbody rb;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(moveHorizontal != 0 || moveVertical != 0)
        {
            Vector3 movement = cam.transform.TransformDirection(new Vector3(moveHorizontal, 0.0f, moveVertical));

            float factor = (Vector3.Angle(rb.velocity, movement)) / 180.0f * turnSpeed + 1;
            rb.velocity += movement * speed * factor * Time.deltaTime;
            rb.velocity = (rb.velocity.magnitude > maxSpeed) ? rb.velocity.normalized * maxSpeed : rb.velocity;
        }
        else
        {
            rb.velocity *= autoBrake;
        }
    }
}
