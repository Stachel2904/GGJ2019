using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Spider : Enemy
{
    public Spider() : base()
    {

    }

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
}
