using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamster : MonoBehaviour
{
    public List<Enemy> enemys;

    // Start is called before the first frame update
    void Start()
    {
        enemys = new List<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].Update();
        }

        StartCoroutine(Spawing.SpawnEnemy(Enums.EnemyType.Spider));
    }

    public static Gamster Get()
    {
        return GameObject.Find("Gamster").GetComponent<Gamster>();
    }
}
