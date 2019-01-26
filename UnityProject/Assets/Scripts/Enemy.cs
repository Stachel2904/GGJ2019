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

    private bool ded;

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

        this.Position = GetTarget();
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
