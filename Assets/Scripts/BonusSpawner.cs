using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Bonus bonus;
    Wave currentWave;
    int currentWaveNumber;
    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;
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
            Bonus spawnedBonus = Instantiate(bonus, new Vector3(spawnPoint.position.x, spawnPoint.position.y + ShipManager.shipRad, spawnPoint.position.z), Quaternion.identity) as Bonus;
            spawnedBonus.transform.SetParent(spawnPoint);
            spawnPoint.Rotate(new Vector3(random1, 0, 0));
            spawnedBonus.transform.SetParent(null);
            spawnedBonus.OnDeath += OnEnemyDeath;
            Destroy(spawnedBonus.gameObject, 15f);
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