﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Spider : Enemy
{
    public Spider() : base()
    {

    }

    public override void Update()
    {
        if (this.Health <= 0)
        {
            TryDestroy();
            return;
        }


    }

    public override void MoveToTarget()
    {
        base.MoveToTarget();
    }

    /// <summary>
    /// Trys to remove this Spider form the enemies list.
    /// </summary>
    /// <returns>Returns true if succesfull.</returns>
    public bool TryDestroy()
    {
        if (Gamster.Get().enemys.Remove(this))
        {
            return true;
        }

        return false;
    }
}
