using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Spider : Enemy
{
    private void Start()
    {
        //GameObject.Find("SoundManager").AddComponent<SoundManager>().playSound("creepingSpider");
        AudioSource.FindObjectOfType<AudioSource>().Play();
    }

    public override void UpdateEnemy()
    {
        base.UpdateEnemy();
    }

    public override void MoveToTarget()
    {
        base.MoveToTarget();
    }

    public override Vector3 DodgePlayer()
    {
        float dist = GetDistanceToPlayer();
        Vector3 newDir;

        //Debug.Log(Vector3.Angle(this.gameObject.GetComponent<Transform>().TransformDirection(Vector3.forward), Position - GetPlayerPosition()));

        if (dist <= 50)
        {
            if (Vector3.Angle(Position - GetPlayerPosition(), this.gameObject.GetComponent<Transform>().TransformDirection(Vector3.back)) <= 90)
            {
                newDir = Quaternion.AngleAxis(90, Vector3.forward) * GetTarget().GetOrthogonalVectorWithoutY(Position);
            }
            else
            {
                newDir = Quaternion.AngleAxis(-90, Vector3.forward) * GetTarget().GetOrthogonalVectorWithoutY(Position);
            }
             
            return newDir;
        }

        return GetTarget();
    }
}
