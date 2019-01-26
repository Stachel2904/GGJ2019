using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum EnemyType
    {
        None,
        Spider,
    }

    public static Dictionary<EnemyType, string> Prefabs = new Dictionary<EnemyType, string>()
    {
        { EnemyType.Spider, "Prefabs/Spider"},
        //{ EnemyType.Cockroach, "Prefabs/Cockroach" }
    };
}

public static class Extention
{
    public static Vector3 GetOrthogonalVectorWithoutY(this Vector3 me, Vector3 other)
    {
        return new Vector3(me.y * other.z - me.z * other.y, 0, me.x * other.y - me.y * other.x);
    }
}

