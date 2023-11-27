using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Enemy enemyToSpawnPrefab;
    private EnemySpawner[] spawners;
    private float timer;
    public float timerMax = 2, timerAmplitude =0.5f;


    private void Start()
    {
        spawners = FindObjectsOfType<EnemySpawner>();
        SetTimer();
    }

    public void Spawn()
    {
        EnemySpawner selectedSpawner = spawners[Random.Range(0,spawners.Length)];
        selectedSpawner.Spawn(enemyToSpawnPrefab);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Spawn();
            SetTimer();
        }
    }

    private void SetTimer()
    {
        timer = timerMax + Random.Range(-timerAmplitude, timerAmplitude);

    }
}
