using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gamster : MonoBehaviour
{
    public List<Enemy> enemys;
    public int[] enemyNums;

    public int killedEnemys;

    // Start is called before the first frame update
    void Start()
    {
        enemys = new List<Enemy>();
        killedEnemys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].UpdateEnemy();
        }

        for (int i = 1; i < Enum.GetNames(typeof(Enums.EnemyType)).Length ; i++)
        {
            if (enemys.Where(e => e.type == (Enums.EnemyType) i).Count() < enemyNums[i-1])
            {
                StartCoroutine(Spawing.SpawnEnemy((Enums.EnemyType) i));
            }
        }
    }

    public static Gamster Get()
    {
        return GameObject.Find("Gamster").GetComponent<Gamster>();
    }
}
