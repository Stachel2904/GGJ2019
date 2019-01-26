using System.Collections;
using System.Linq;
using System;
using UnityEngine;

public class Spawing : MonoBehaviour
{
    [SerializeField]
    private int numSpawnPoints;
    public int NumSpawnPoints { get { return numSpawnPoints; } set { numSpawnPoints = value; } }

    [SerializeField]
    private Transform[] spawnPoints;
    public Transform[] SpawnPoints { get { return spawnPoints; } set { spawnPoints = value; } }

    private Enemy[] lastEnemyAtSpawnPoint;

    public static Spawing Get()
    {
        return GameObject.Find("Gamster").GetComponent<Spawing>();
    }

    public void Start()
    {
        numSpawnPoints = SpawnPoints.Length;
        lastEnemyAtSpawnPoint = new Enemy[numSpawnPoints];
    }

    /// <summary>
    /// Picks random one of the possible SpawingPoints for a Enemy.
    /// </summary>
    /// <returns>Returns Vector3 with Position of SpawingPoint.</returns>
    public int GetSpawnPoint()
    {
        return UnityEngine.Random.Range(0, numSpawnPoints);
    }

    public bool GetSpawnPoint(out int pos)
    {
        pos = UnityEngine.Random.Range(0, numSpawnPoints);
        return true;
    }

    /// <summary>
    /// Spawns one Enemy at one of the spawning points.
    /// </summary>
    /// <param name="type">EnemyType for the enemy.</param>
    /// <returns>IEnumerator</returns>
    public static IEnumerator SpawnEnemy()
    {
        int index = Gamster.Get().coRoutines + 1;
        Gamster.Get().coRoutines++;
        Enemy enemy;
        int pos = 0;

        while (true)
        {

            while (true)//Get().lastEnemyAtSpawnPoint[pos] != null && Vector3.Distance(Get().lastEnemyAtSpawnPoint[pos].Position, Get().spawnPoints[pos].position) <= 10f)
            {
                pos = Get().GetSpawnPoint();

                if (Get().lastEnemyAtSpawnPoint[pos] != null && Vector3.Distance(Get().lastEnemyAtSpawnPoint[pos].Position, Get().spawnPoints[pos].position) <= 10f)
                {
                    yield return new WaitForEndOfFrame();
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (Gamster.Get().enemys.Where(e => e.type == (Enums.EnemyType)index).Count() < Gamster.Get().enemyNums[index - 1])
            {
                enemy = Instantiate<Enemy>(Resources.Load<Enemy>(Enums.Prefabs[(Enums.EnemyType)index]), Get().spawnPoints[pos].position, Quaternion.Euler(Vector3.zero));

                enemy.type = (Enums.EnemyType)index;

                Gamster.Get().enemys.Add(enemy);
                Get().lastEnemyAtSpawnPoint[pos] = enemy;
            }

            yield return new WaitUntil(() => Gamster.Get().enemys.Where(e => e.type == (Enums.EnemyType)index).Count() < Gamster.Get().enemyNums[index - 1]);
        }
    }
}
