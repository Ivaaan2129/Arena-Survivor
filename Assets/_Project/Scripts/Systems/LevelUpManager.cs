using UnityEngine;
using System.Collections.Generic;

public class LevelUpManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAutoShoot playerAutoShoot;
    private PlayerHealth playerHealth;

    [SerializeField] private LevelUpUI levelUpUI;

    private List<UpgradeType> currentChoices = new List<UpgradeType>();

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            playerAutoShoot = player.GetComponent<PlayerAutoShoot>();
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    public void StartLevelUpChoice()
    {
        Time.timeScale = 0f;

        GenerateRandomChoices();

        levelUpUI.Show(currentChoices.ToArray());
    }

    private void GenerateRandomChoices()
    {
        List<UpgradeType> allUpgrades = new List<UpgradeType>()
        {
            UpgradeType.MoveSpeed,
            UpgradeType.FireRate,
            UpgradeType.MagicBoltDamage,
            UpgradeType.ProjectileSpeed,
            UpgradeType.MaxHealth,
            UpgradeType.Heal
        };

        ShuffleList(allUpgrades);

        currentChoices = new List<UpgradeType>
        {
            allUpgrades[0],
            allUpgrades[1],
            allUpgrades[2]
        };
    }

    private void ShuffleList(List<UpgradeType> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);

            UpgradeType temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void ApplyUpgrade(UpgradeType upgrade)
    {
        switch (upgrade)
        {
            case UpgradeType.MoveSpeed:
                if (playerMovement != null)
                {
                    playerMovement.IncreaseMoveSpeed(1f);
                    Debug.Log("Move Speed Up");
                }
                break;

            case UpgradeType.FireRate:
                if (playerAutoShoot != null)
                {
                    playerAutoShoot.IncreaseFireRate(0.1f);
                    Debug.Log("Fire Rate Up");
                }
                break;

            case UpgradeType.MagicBoltDamage:
                if (playerAutoShoot != null)
                {
                    playerAutoShoot.IncreaseMagicBoltDamage(1);
                    Debug.Log("Magic Bolt Damage Up");
                }
                break;

            case UpgradeType.ProjectileSpeed:
                if (playerAutoShoot != null)
                {
                    playerAutoShoot.IncreaseProjectileSpeed(2f);
                    Debug.Log("Projectile Speed Up");
                }
                break;

            case UpgradeType.MaxHealth:
                if (playerHealth != null)
                {
                    playerHealth.IncreaseMaxHealth(2);
                    Debug.Log("Max Health Up");
                }
                break;

            case UpgradeType.Heal:
                if (playerHealth != null)
                {
                    playerHealth.Heal(3);
                    Debug.Log("Heal");
                }
                break;
        }

        Time.timeScale = 1f;
    }
}