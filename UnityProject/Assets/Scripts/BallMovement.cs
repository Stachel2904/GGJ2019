using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject cam;
    public float speed = 50f;

    private Rigidbody rb;

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

        Vector3 movement = cam.transform.TransformDirection(new Vector3(moveHorizontal, 0.0f, moveVertical));

        rb.AddForce(movement * speed);
        
        
    }
}
