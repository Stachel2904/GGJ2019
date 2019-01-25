using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Vector3 position;
    public Vector3 Position {
        get
        {
            return position;
        }
        set
        {
            position += value;
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.GetComponent<Transform>().TransformDirection(new Vector3(value.x, this.gameObject.GetComponent<Rigidbody>().velocity.y, value.z));
        }
    }

    [SerializeField]
    private int health;
    public int Health { get; set; }

    [SerializeField]
    private int speed;
    public int Speed { get; set;
    }

    [SerializeField]
    private Vector3 target;
    public Vector3 Target { get; set; }

    private Enemy instance;

    public void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void MoveToTarget()
    {
        this.position += Vector3.one;
    }
}
