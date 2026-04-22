using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    [Header("Spawn Settings")]
    public float startSpawnInterval = 2f;
    public float minimumSpawnInterval = 0.5f;
    public float spawnDistance = 8f;

    [Header("Difficulty Scaling")]
    public float difficultyIncreaseRate = 0.05f;
    public float timeBetweenExtraEnemies = 20f;
    public int maxEnemiesPerWave = 4;

    private float spawnTimer;
    private float currentSpawnInterval;
    private float survivalTimer;

    private void Start()
    {
        currentSpawnInterval = startSpawnInterval;

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    private void Update()
    {
        if (player == null || enemyPrefab == null) return;

        survivalTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        UpdateDifficulty();

        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnWave();
            spawnTimer = 0f;
        }
    }

    private void UpdateDifficulty()
    {
        currentSpawnInterval = startSpawnInterval - (survivalTimer * difficultyIncreaseRate);
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, minimumSpawnInterval);
    }

    private void SpawnWave()
    {
        int enemiesToSpawn = 1 + Mathf.FloorToInt(survivalTimer / timeBetweenExtraEnemies);
        enemiesToSpawn = Mathf.Clamp(enemiesToSpawn, 1, maxEnemiesPerWave);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        if (randomDirection == Vector2.zero)
        {
            randomDirection = Vector2.right;
        }

        Vector2 spawnPosition = (Vector2)player.position + randomDirection * spawnDistance;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}