using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float spawnInterval = 2f;
    public float spawnDistance = 8f;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null)
            return;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)player.position + randomDirection * spawnDistance;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}