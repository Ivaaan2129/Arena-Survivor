using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    public int experienceAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("La gema ha tocado: " + other.name);

        if (!other.CompareTag("Player"))
            return;

        Debug.Log("La gema ha detectado al Player");

        PlayerExperience playerExperience = other.GetComponent<PlayerExperience>();

        if (playerExperience != null)
        {
            Debug.Log("Se ha encontrado PlayerExperience y se suma XP");
            playerExperience.AddExperience(experienceAmount);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No se encontró PlayerExperience en el Player");
        }
    }
}