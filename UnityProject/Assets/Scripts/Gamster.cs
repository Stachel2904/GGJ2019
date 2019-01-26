using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gamster : MonoBehaviour
{
    public List<Enemy> enemys;
    public int[] enemyNums;
    public Transform Target;

    public int killedEnemys;
    public int coRoutines;

    // Start is called before the first frame update
    void Start()
    {
        enemys = new List<Enemy>();
        killedEnemys = 0;
        coRoutines = 0;

        for (int i = 1; i <Enum.GetNames(typeof(Enums.EnemyType)).Length; i++)
        {
            StartCoroutine(Spawing.SpawnEnemy());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].UpdateEnemy();
        }

        
    }

    public static Gamster Get()
    {
        return GameObject.Find("Gamster").GetComponent<Gamster>();
    }
}
