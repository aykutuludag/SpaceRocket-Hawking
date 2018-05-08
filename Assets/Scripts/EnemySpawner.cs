using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    public ShipManager shipManager;
    public Transform player;
    public Transform spawnPoint;

    void Start()
    {
        NextWave();
    }

    void Update()
    {

        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime && ShipManager.isGameStarted && !ShipManager.isGameOver && !ShipManager.paused)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
            int random1 = Random.Range(0, 360);
            Enemy spawnedEnemy = Instantiate(enemy, new Vector3(spawnPoint.position.x, spawnPoint.position.y + ShipManager.shipRad, spawnPoint.position.z), Quaternion.identity) as Enemy;
            spawnedEnemy.transform.SetParent(spawnPoint);
            spawnPoint.Rotate(new Vector3(random1, 0, 0));
            spawnedEnemy.transform.SetParent(null);
            spawnedEnemy.OnDeath += OnEnemyDeath;
            Destroy(spawnedEnemy.gameObject, 15f);
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        print("Wave: " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}