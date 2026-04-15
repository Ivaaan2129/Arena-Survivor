using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LevelUpManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAutoShoot playerAutoShoot;

    private bool isChoosingUpgrade = false;
    private List<UpgradeType> currentChoices = new List<UpgradeType>();

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            playerAutoShoot = player.GetComponent<PlayerAutoShoot>();
        }
    }

    private void Update()
    {
        if (!isChoosingUpgrade)
            return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ApplyUpgrade(currentChoices[0]);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ApplyUpgrade(currentChoices[1]);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ApplyUpgrade(currentChoices[2]);
        }
    }

    public void StartLevelUpChoice()
    {
        isChoosingUpgrade = true;
        Time.timeScale = 0f;

        GenerateRandomChoices();

        Debug.Log("LEVEL UP! Elige una mejora:");
        Debug.Log("1 - " + currentChoices[0]);
        Debug.Log("2 - " + currentChoices[1]);
        Debug.Log("3 - " + currentChoices[2]);
    }

    private void GenerateRandomChoices()
    {
        List<UpgradeType> allUpgrades = new List<UpgradeType>()
        {
            UpgradeType.MoveSpeed,
            UpgradeType.FireRate,
            UpgradeType.MagicBoltDamage
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

    private void ApplyUpgrade(UpgradeType upgrade)
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
        }

        isChoosingUpgrade = false;
        Time.timeScale = 1f;
    }
}