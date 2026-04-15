using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentExperience = 0;
    public int experienceToNextLevel = 5;

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
    }
}