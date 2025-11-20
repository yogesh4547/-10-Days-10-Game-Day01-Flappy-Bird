using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float minY = -2f;
    [SerializeField] private float maxY = 2f;

    private float spawnTimer = 0f;
    private bool canSpawn = true;

    void Update()
    {
        if (!canSpawn) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            SpawnPipe();
            spawnTimer = 0f;
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);

        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }

    public void StartSpawning()
    {
        canSpawn = true;
        spawnTimer = 0f;
    }
}
