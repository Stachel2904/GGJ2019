using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : Enemy
{
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
        //ToDo other implementation
        Vector3 playerPos = GameObject.Find("Ball").GetComponent<Transform>().position;

        float dist = Vector3.Distance(Position, playerPos);

        if (dist <= 50)
        {
            Vector3 newDir = Quaternion.AngleAxis(90, Vector3.forward) * GetTarget().GetOrthogonalVectorWithoutY(Position);

            return newDir;
        }

        return GetTarget();
    }
}
