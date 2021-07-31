using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public EnemyHealthScript[] enemies;

        public int count;

        public float timeBetweenSpawns;
    }

    public Wave[] waves;

    public Transform[] spawnPoints;

    public float timeBetweenWaves;

    public GameObject bossEnemy;

    public Transform bossEnemySpawnPoint;

    private Wave currentWave;

    private int currentWaveIndex;

    private Transform playerTransform;

    private bool finishedSpawning;
    
    private GameObject BossHealthBar;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    void Update()
    {
        if (
            finishedSpawning == true &&
            GameObject.FindGameObjectsWithTag("Enemy").Length <= 0
        )
        {
            finishedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                // show boss health bar
                BossHealthBar.SetActive(true);

                // instantiate the boss
                Instantiate(bossEnemy,
                bossEnemySpawnPoint.position,
                bossEnemySpawnPoint.rotation);
            }
        }
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for (int i = 0; i < currentWave.count; i++)
        {
            if (playerTransform == null)
            {
                yield break;
            }
            else
            {
                EnemyHealthScript randomEnemy =
                    currentWave
                        .enemies[Random.Range(0, currentWave.enemies.Length)];
                Transform randomSpawnPoint =
                    spawnPoints[Random.Range(0, spawnPoints.Length)];

                Instantiate(randomEnemy,
                randomSpawnPoint.position,
                randomSpawnPoint.rotation);

                if (i == currentWave.count - 1)
                {
                    finishedSpawning = true;
                }
                else
                {
                    finishedSpawning = false;
                }

                yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
            }
        }
    }
}
