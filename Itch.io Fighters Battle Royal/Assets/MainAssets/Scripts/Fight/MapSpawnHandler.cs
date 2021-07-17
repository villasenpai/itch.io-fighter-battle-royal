using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnHandler : MonoBehaviour
{

    [SerializeField] List<Transform> spawnPoints;

    public List<Transform> GetSpawnPoints()
    {
        return spawnPoints;
    }
}
