using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 Position {
        get
        {
            return this.gameObject.GetComponent<Transform>().position;
        }
        set
        {
            this.gameObject.GetComponent<Transform>().position = Vector3.MoveTowards(this.gameObject.GetComponent<Transform>().position, value, Time.deltaTime * speed);
        }
    }

    [SerializeField]
    private int health;
    public int Health { get { return health; } set { health = value; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    public Enums.EnemyType type;

    public void Start()
    {

    }

    /// <summary>
    /// Updates the Enemy stats.
    /// </summary>
    public virtual void UpdateEnemy()
    {
        if (this.Health <= 0)
        {
            TryDestroy();
            return;
        }

        MoveToTarget();
    }

    /// <summary>
    /// Moves the Enemy directly to the target.
    /// (In a straight line.)
    /// </summary>
    public virtual void MoveToTarget()
    {
        this.transform.LookAt(GetTarget());
        this.transform.Rotate(Vector3.up*180);



        this.Position = DodgePlayer();
    }

    /// <summary>
    /// Trys to dodge the Player, with a orthogonal movement direction.
    /// </summary>
    /// <returns>Returns Vector3 with move direction.</returns>
    public virtual Vector3 DodgePlayer()
    {
        Vector3 playerPos = GameObject.Find("Ball").GetComponent<Transform>().position;

        float dist = Vector3.Distance(Position, playerPos);

        if (dist <= 50)
        {
            return Vector3.Cross(playerPos, Position)*10;
        }

        return GetTarget();
    }

    /// <summary>
    /// Calculates the target for the Enemy.
    /// </summary>
    /// <returns>Returns Vector3 position of target.</returns>
    public Vector3 GetTarget()
    {
        Vector3 dir = GameObject.Find("Chair").GetComponent<Transform>().position;

        return new Vector3(dir.x, 0, dir.z);
    }

    /// <summary>
    /// Trys to remove this Spider form the enemies list.
    /// </summary>
    /// <returns>Returns true if succesfull.</returns>
    public bool TryDestroy()
    {
        if (Gamster.Get().enemys.Remove(this))
        {
            Destroy(this);
            Gamster.Get().killedEnemys++;

            return true;
        }

        return false;
    }
}
