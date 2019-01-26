using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private bool ded;

    //NavMeshAgent agent;

    public void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //agent.destination = GetTarget();
    }

    /// <summary>
    /// Updates the Enemy stats.
    /// </summary>
    public virtual void UpdateEnemy()
    {
        if (this.Health <= 0)
        {
            TryRemove();
            return;
        }

        MoveToTarget();
        CheckTargetReached();

        //if (GetDistanceToPlayer() <= 40f)
        //{
        //    agent.isStopped = true;
        //    MoveToTarget();
        //}
        //else
        //{
        //    this.transform.Rotate(Vector3.up * 180);
        //    agent.isStopped = false;
        //}

    }

    /// <summary>
    /// Moves the Enemy directly to the target.
    /// (In a straight line.)
    /// </summary>
    public virtual void MoveToTarget()
    {
        Vector3 dir = DodgePlayer();
        this.transform.LookAt(dir);
        this.transform.Rotate(Vector3.up*180);
        
        this.Position = dir;

        //if(CheckTargetReached())
        //{
        //    GameObject.Find("Player").GetComponent<PlayerBehaviour>().RemoveLivePoints(50);
        //    TryRemove(true);
        //}
    }

    /// <summary>
    /// Trys to dodge the Player, with a orthogonal movement direction.
    /// </summary>
    /// <returns>Returns Vector3 with move direction.</returns>
    public virtual Vector3 DodgePlayer()
    {
        return Vector3.one;
    }

    /// <summary>
    /// Calculates the target for the Enemy.
    /// </summary>
    /// <returns>Returns Vector3 position of target.</returns>
    public Vector3 GetTarget()
    {
        Vector3 dir = Gamster.Get().Target.position;

        return new Vector3(dir.x, 0, dir.z);
    }

    protected float GetDistanceToPlayer()
    {
        Vector3 playerPos = GameObject.Find("Ball").GetComponent<Transform>().position;

        float dist = Vector3.Distance(Position, playerPos);

        return dist;
    }

    protected Vector3 GetPlayerDirection()
    {
        return GameObject.Find("Ball").GetComponent<Transform>().forward;
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(this.Position, GetTarget());
    }

    public void CheckTargetReached()
    {
        if (DistanceToTarget() <= 5)
        {
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().RemoveLivePoints(50);
            //Gamster.Get().MasterLife -= 5;
            TryRemove(true);
        }
    }

    /// <summary>
    /// Trys to remove this Spider form the enemies list.
    /// </summary>
    /// <returns>Returns true if succesfull.</returns>
    public bool TryRemove(bool target = false)
    {
        if (target)
        {
            if (Gamster.Get().enemys.Remove(this))
            {
                Destroy(this.gameObject);

                return true;
            }
        }
        else
        {
            if (Gamster.Get().enemys.Remove(this))
            {
                Gamster.Get().killedEnemys++;

                return true;
            }
        }

        return false;
    }

    public IEnumerator Squish()
    {
        TryRemove();

        Destroy(this.gameObject.GetComponent<BoxCollider>());
        Destroy(this.gameObject.GetComponent<Animator>());

        while(this.gameObject.transform.localScale.y - (Time.deltaTime / 10) > 0.0001f)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y - (Time.deltaTime / 10), this.gameObject.transform.localScale.z);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        while(this.gameObject.transform.localScale.x > 0 && this.gameObject.transform.localScale.z > 0)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x - (Time.deltaTime / 10), 0.0001f , this.gameObject.transform.localScale.z - (Time.deltaTime / 10));
            yield return new WaitForEndOfFrame();
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && !ded)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound(this.gameObject.GetComponent<AudioSource>(), "squishSpider");
            ded = true;
            StartCoroutine(Squish());
        }
    }
}
