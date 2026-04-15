using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public GameObject experiencePickupPrefab;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (experiencePickupPrefab != null)
        {
            Instantiate(experiencePickupPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}