using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamtaroRotation : MonoBehaviour
{
    int actualRotation;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        if (moveHorizontal > 0)
        {
            rotateSTuff(90);
        }
        else if (moveHorizontal < 0)
        {
            rotateSTuff(-90);
        }
        else if (moveVertical > 0)
        {
            rotateSTuff(0);
        }
        else if (moveVertical < 0)
        {
            rotateSTuff(180);
        }

        if (moveVertical > 0 && moveHorizontal > 0)
        {
            rotateSTuff(45);
        }
        else if (moveVertical > 0 && moveHorizontal < 0)
        {
            rotateSTuff(-45);
        }
        else if (moveVertical < 0 && moveHorizontal > 0)
        {
            rotateSTuff(135);
        }
        else if (moveVertical < 0 && moveHorizontal < 0)
        {
            rotateSTuff(-135);
        }
        if(this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            this.gameObject.transform.rotation = Quaternion.LookRotation(this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().velocity, Vector3.up);
        }

    }

    void rotateSTuff(int rotation)
    {
        this.gameObject.transform.localRotation = Quaternion.Euler(cam.transform.localRotation.eulerAngles + new Vector3(0, rotation, 0));
    }
}
