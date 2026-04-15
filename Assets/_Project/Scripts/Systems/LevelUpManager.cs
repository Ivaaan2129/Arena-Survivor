using UnityEngine;
using UnityEngine.InputSystem;

public class LevelUpManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAutoShoot playerAutoShoot;

    private bool isChoosingUpgrade = false;

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
            ApplyUpgrade(1);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ApplyUpgrade(2);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ApplyUpgrade(3);
        }
    }

    public void StartLevelUpChoice()
    {
        isChoosingUpgrade = true;
        Time.timeScale = 0f;

        Debug.Log("LEVEL UP! Elige una mejora:");
        Debug.Log("1 - Move Speed Up");
        Debug.Log("2 - Fire Rate Up");
        Debug.Log("3 - Magic Bolt Damage Up");
    }

    private void ApplyUpgrade(int option)
    {
        switch (option)
        {
            case 1:
                if (playerMovement != null)
                {
                    playerMovement.IncreaseMoveSpeed(1f);
                    Debug.Log("Mejora aplicada: Move Speed Up");
                }
                break;

            case 2:
                if (playerAutoShoot != null)
                {
                    playerAutoShoot.IncreaseFireRate(0.1f);
                    Debug.Log("Mejora aplicada: Fire Rate Up");
                }
                break;

            case 3:
                if (playerAutoShoot != null)
                {
                    playerAutoShoot.IncreaseMagicBoltDamage(1);
                    Debug.Log("Mejora aplicada: Magic Bolt Damage Up");
                }
                break;
        }

        isChoosingUpgrade = false;
        Time.timeScale = 1f;
    }
}