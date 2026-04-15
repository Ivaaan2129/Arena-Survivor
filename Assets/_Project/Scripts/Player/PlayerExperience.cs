using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentExperience = 0;
    public int experienceToNextLevel = 5;

    private LevelUpManager levelUpManager;

    private void Start()
    {
        levelUpManager = FindFirstObjectByType<LevelUpManager>();
    }

    public void AddExperience(int amount)
    {
        currentExperience += amount;
        Debug.Log("XP actual: " + currentExperience + " / " + experienceToNextLevel);

        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentExperience = 0;
        experienceToNextLevel += 3;

        Debug.Log("¡Level Up! Nivel actual: " + currentLevel);

        if (levelUpManager != null)
        {
            levelUpManager.StartLevelUpChoice();
        }
    }
}