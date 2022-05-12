using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public IntValue level;
    public IntValue playerXp;
    
    private int nextLevelXp = 100;
    private int availableSkillPoints = 0;

    private void LevelUp()
    {
        level.Value++;
        availableSkillPoints++;

        playerXp.Value = 0;
        nextLevelXp *= 2;
    }

    public void IncreaseXp(int amount)
    {
        int xpNeededToLevelUp = nextLevelXp - playerXp.Value;

        while (amount >= xpNeededToLevelUp)
        {
            amount -= xpNeededToLevelUp;
            LevelUp();
            xpNeededToLevelUp = nextLevelXp - playerXp.Value;
        }

        playerXp.Value += amount;
    }

    public int GetAvailableSkillPoints()
    {
        return availableSkillPoints;
    }
}
