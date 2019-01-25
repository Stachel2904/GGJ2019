using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawing : MonoBehaviour
{
    [SerializeField]
    private int numSpawnPoints = 2;
    public int NumSpawnPoints { get { return numSpawnPoints; } set { numSpawnPoints = value; } }

    [SerializeField]
    private Vector3[] spawnPoints;
    public Vector3[] SpawnPoints { get { return spawnPoints; } set { spawnPoints = value; } }

    private Enemy[] lastEnemyAtSpawnPoint = new Enemy[2];

    public static Spawing Get()
    {
        return GameObject.Find("Gamster").GetComponent<Spawing>();
    }

    public void Start()
    {
        lastEnemyAtSpawnPoint = new Enemy[numSpawnPoints];
    }

    /// <summary>
    /// Picks random one of the possible SpawingPoints for a Enemy.
    /// </summary>
    /// <returns>Returns Vector3 with Position of SpawingPoint.</returns>
    public int GetSpawnPoint()
    {
        return Random.Range(0, numSpawnPoints);
    }

    /// <summary>
    /// Spawns one Enemy at one of the spawning points.
    /// </summary>
    /// <param name="type">EnemyType for the enemy.</param>
    /// <returns>IEnumerator</returns>
    public static IEnumerator SpawnEnemy(Enums.EnemyType type)
    {
        int pos = Get().GetSpawnPoint();
        
        while (Get().lastEnemyAtSpawnPoint[pos] != null && Vector3.Distance(Get().lastEnemyAtSpawnPoint[pos].Position, Get().spawnPoints[pos]) <= 10f)
        {
            yield return new WaitForSeconds(0.1f); // Random.Range(0.1f, (100 - Mathf.Log(Gamster.Get().killedEnemys) - Gamster.Get().killedEnemys)));
            
        }
        
        Enemy enemy = Instantiate<Enemy>(Resources.Load<Enemy>(Enums.Prefabs[type]), Get().spawnPoints[pos], Quaternion.Euler(Vector3.zero));

        enemy.type = type;
        
        Gamster.Get().enemys.Add(enemy);
        Get().lastEnemyAtSpawnPoint[pos] = enemy;
    }
}
