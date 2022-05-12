using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;

    public Action<int> OnLevelUp;

    private int xp = 0;
    private int nextLevelXp = 100;
    private int availableSkillPoints = 0;

    private void LevelUp()
    {
        level++;
        availableSkillPoints++;
        xp = 0;
        nextLevelXp *= 2;

        OnLevelUp?.Invoke(level);
    }

    public void IncreaseXp(int amount)
    {
        int xpNeededToLevelUp = nextLevelXp - xp;

        while (amount >= xpNeededToLevelUp)
        {
            amount -= xpNeededToLevelUp;
            LevelUp();
            xpNeededToLevelUp = nextLevelXp - xp;
        }

        xp += amount;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetAvailableSkillPoints()
    {
        return availableSkillPoints;
    }
}
