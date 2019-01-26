using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gamster : MonoBehaviour
{
    [SerializeField]
    private int masterLife;
    public int MasterLife { get { return masterLife; } set { masterLife = value; } }

    public List<Enemy> enemys;
    public int[] enemyNums;
    public Transform Target;

    public int killedEnemys;  //Score
    public int coRoutines;

    private float SpawnRate = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
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
        if(SpawnRate > 10.0f)
        {
            enemyNums[(int)Enums.EnemyType.Spider - 1]++;
            SpawnRate = 0;
        }
        else
        {
            SpawnRate += Time.deltaTime;
        }
    }

    public static Gamster Get()
    {
        return GameObject.Find("Gamster").GetComponent<Gamster>();
    }
}
