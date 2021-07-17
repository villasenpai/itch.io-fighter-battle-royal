
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> fighterPrefab;
    List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = FindObjectOfType<MapSpawnHandler>().GetSpawnPoints();

        SpawnFighters();
    }

    private void SpawnFighters()
    {
        FightManager.fightManager.totalFighters = fighterPrefab.Count;
        while (fighterPrefab.Count > 0)
        {

            int fighterIndex = Random.Range(0, fighterPrefab.Count);
            int spawnPointIndex = Random.Range(0, spawnPoints.Count);

            Instantiate(fighterPrefab[fighterIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            fighterPrefab.RemoveAt(fighterIndex);
            spawnPoints.RemoveAt(spawnPointIndex);
        }

    }
}
