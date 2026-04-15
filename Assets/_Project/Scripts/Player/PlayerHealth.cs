using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Vida actual del jugador: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("El jugador recibió daño. Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Game Over");
        gameObject.SetActive(false);
    }
}