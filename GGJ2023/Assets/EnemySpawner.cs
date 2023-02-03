using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    public float spawnDistance;
    public int dayCounter = 10;
    public GameObject[] spawnerPoints => GameObject.FindGameObjectsWithTag("SpawnPoint");

    void Start()
    {
        spawnRepating();
    }

    public void spawnRepating()
    {
        for (int i = 0; i < 1; i++)
        {
            spawnEnemy();
        }
    }
    void spawnEnemy()
    {
        Vector3 spawnPosition = spawnerPoints[Random.Range(0,spawnerPoints.Length)].transform.position;
        spawnPosition.x += Random.Range(-spawnDistance,spawnDistance);
        spawnPosition.y = -2f;
        Instantiate(Enemy,spawnPosition,Quaternion.identity,GameObject.FindGameObjectWithTag("EnemyParent").transform);
    }
}
