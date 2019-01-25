using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawing : MonoBehaviour
{
    [SerializeField]
    private static int numSpawnPoints;
    public int NumSpawnPoints { get { return numSpawnPoints; } set { numSpawnPoints = value; } }

    [SerializeField]
    private static Vector3[] spawnPoints;
    public Vector3[] SpawnPoints { get { return spawnPoints; } set { spawnPoints = value; } }

    private static Enemy[] lastEnemyAtSpawnPoint;

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
    public static int GetSpawnPoint()
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
        int pos = GetSpawnPoint();

        while (lastEnemyAtSpawnPoint[pos] != null && Vector3.Distance(lastEnemyAtSpawnPoint[pos].Position, spawnPoints[pos]) >= 0.5f)
        {
            yield return new WaitForSeconds(0.1f);
        }

        Enemy enemy = Instantiate<Enemy>(Resources.Load<Enemy>(Enums.Prefabs[type]), spawnPoints[pos], Quaternion.Euler(Vector3.zero));

        Gamster.Get().enemys.Add(enemy);
    }

    

}
