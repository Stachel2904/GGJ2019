using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Spider : Enemy
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
        float dist = GetDistanceToPlayer();

        if (dist <= 50)
        {
            Vector3 newDir = Quaternion.AngleAxis(90, Vector3.forward) * GetTarget().GetOrthogonalVectorWithoutY(Position);

            return newDir;
        }

        return GetTarget();
    }
}
