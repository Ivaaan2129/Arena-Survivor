using UnityEngine;

public class PlayerAutoShoot : MonoBehaviour
{
    public GameObject magicBoltPrefab;
    public float fireRate = 0.75f;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Transform nearestEnemy = FindNearestEnemy();

            if (nearestEnemy != null)
            {
                Shoot(nearestEnemy);
                fireTimer = 0f;
            }
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
            return null;

        Transform nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }

    private void Shoot(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;

        GameObject magicBolt = Instantiate(magicBoltPrefab, transform.position, Quaternion.identity);

        MagicBoltProjectile projectile = magicBolt.GetComponent<MagicBoltProjectile>();

        if (projectile != null)
        {
            projectile.SetDirection(direction);
        }
    }
}