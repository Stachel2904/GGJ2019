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
            TryDestroy();
            return;
        }

        MoveToTarget();

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

        if(Vector3.Distance(this.gameObject.transform.position, Gamster.Get().Target.position) < 1.0f)
        {
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().RemoveLivePoints(50);
            TryDestroy();
        }
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

    /// <summary>
    /// Trys to remove this Spider form the enemies list.
    /// </summary>
    /// <returns>Returns true if succesfull.</returns>
    public bool TryDestroy()
    {
        if (Gamster.Get().enemys.Remove(this))
        {
            Destroy(this.gameObject);
            Gamster.Get().killedEnemys++;
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().CurrentScorePoints += 25;
            return true;
        }

        return false;
    }

    public IEnumerator Squish()
    {

        Destroy(this.gameObject.GetComponent<BoxCollider>());
        Destroy(this.gameObject.GetComponent<Animator>());
        Gamster.Get().enemys.Remove(this);
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
       GameObject.Destroy(this.gameObject);
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
