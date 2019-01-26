using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamtaroRotation : MonoBehaviour
{
    int actualRotation;
    public GameObject cam;
    private float RollSoundFrequency = -1;
    public float rollSoundFactor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RollSound());
    }

    // Update is called once per frame
    void Update()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");


        //if (moveHorizontal > 0)
        //{
        //    rotateSTuff(90);
        //}
        //else if (moveHorizontal < 0)
        //{
        //    rotateSTuff(-90);
        //}
        //else if (moveVertical > 0)
        //{
        //    rotateSTuff(0);
        //}
        //else if (moveVertical < 0)
        //{
        //    rotateSTuff(180);
        //}

        //if (moveVertical > 0 && moveHorizontal > 0)
        //{
        //    rotateSTuff(45);
        //}
        //else if (moveVertical > 0 && moveHorizontal < 0)
        //{
        //    rotateSTuff(-45);
        //}
        //else if (moveVertical < 0 && moveHorizontal > 0)
        //{
        //    rotateSTuff(135);
        //}
        //else if (moveVertical < 0 && moveHorizontal < 0)
        //{
        //    rotateSTuff(-135);
        //}
        Vector3 velocity = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().velocity;
        if (velocity != Vector3.zero)
        {
            this.gameObject.transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);

            Vector3 BallRotation = this.gameObject.transform.TransformDirection(Vector3.right);
            GameObject.Find("Ball").transform.Rotate(BallRotation * velocity.magnitude * 0.07f, Space.World);

            RollSoundFrequency = velocity.magnitude * rollSoundFactor;
        }
        else
        {
            RollSoundFrequency = -1;
        }
    }

    private IEnumerator RollSound()
    {
        while (true)
        {
            while (RollSoundFrequency > 0)
            {
                if (!this.gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    this.gameObject.GetComponent<AudioSource>().Play();
                }
                Debug.Log("Waiting for " + 1 / (RollSoundFrequency + 1) + "s.");
                yield return new WaitForSeconds(1 / (RollSoundFrequency + 1));
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void rotateSTuff(int rotation)
    {
        this.gameObject.transform.localRotation = Quaternion.Euler(cam.transform.localRotation.eulerAngles + new Vector3(0, rotation, 0));
    }
}
