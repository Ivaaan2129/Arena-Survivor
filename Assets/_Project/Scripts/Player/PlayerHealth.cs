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

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;

        Debug.Log("Vida máxima aumentada. Vida actual: " + currentHealth + " / " + maxHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        Debug.Log("Jugador curado. Vida actual: " + currentHealth + " / " + maxHealth);
    }

    private void Die()
    {
        Debug.Log("Game Over");
        gameObject.SetActive(false);
    }
}