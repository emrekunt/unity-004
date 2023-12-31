using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;
    public bool hasWaveFinished = true;

    private readonly float spawnRange = 9f;
    public int enemyCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //CreateEnemyWave();
    }

    private void Update()
    {
        CheckEnemyCount();
    }

    private Vector3 RandomSpawnPosition()
    {
        var spawnPosX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        var spawnPosZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void CreateEnemyWave()
    {
        if (hasWaveFinished)
        {
            for (int k = 0; k < enemyCount; k++)
            {
                var enemyIndex = new System.Random().Next(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[enemyIndex],
                            RandomSpawnPosition(),
                            enemyPrefabs[enemyIndex].transform.rotation);
            }
            hasWaveFinished = false;
        }

    }

    private void CheckEnemyCount()
    {
        var currentEnemyCount = FindObjectsOfType<EnemyController>().Length;
        Debug.Log("currentEnemyCount : " + currentEnemyCount);
        if (currentEnemyCount == 0)
        {
            hasWaveFinished = true;
            enemyCount++;
            CreateEnemyWave();
            CreatePowerup();
        }
    }

    private void CreatePowerup()
    {
        Instantiate(powerupPrefab, RandomSpawnPosition(), powerupPrefab.transform.rotation);
    }
}
