using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum EnemyType
    {
        None,
        Spider,
        Cockroach
    }

    public static Dictionary<EnemyType, string> Prefabs = new Dictionary<EnemyType, string>()
    {
        { EnemyType.Spider, "Prefabs/Spider"},
        {EnemyType.Cockroach, "Prefabs/Cockroach" }
    };
}

