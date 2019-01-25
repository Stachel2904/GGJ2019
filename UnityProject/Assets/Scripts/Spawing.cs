using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawing : MonoBehaviour
{
    [SerializeField]
    private int numSpawnPoints;
    public int NumSpawnPoints { get; set; }

    [SerializeField]
    private static Vector3[] spawnPoints;
    public static Vector3[] SpawnPoints { get; set; }

    /// <summary>
    /// Picks random one of the possible SpawingPoints for a Enemy.
    /// </summary>
    /// <returns>Returns Vector3 with Position of SpawingPoint.</returns>
    public static int GetSpawnPoint()
    {
        return 0;
    }

    public static IEnumerator SpawnEnemy(Enums.EnemyType type, int pos)
    {
        while ()
        {

        }
        Enemy enemy = Instantiate<Enemy>(Resources.Load<Enemy>(Enums.Prefabs[type]), spawnPoints[pos], Quaternion.Euler(Vector3.zero));
    }

    

}
