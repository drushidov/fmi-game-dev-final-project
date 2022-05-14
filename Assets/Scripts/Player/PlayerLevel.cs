using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public IntValue level;
    public IntValue playerXp;
    public IntValue nextLevelXp;
    public IntValue availableSkillPoints;

    private void LevelUp()
    {
        level.Value++;
        availableSkillPoints.Value++;

        playerXp.Value = 0;
        nextLevelXp.Value *= 2;
    }

    public void IncreaseXp(int amount)
    {
        int xpNeededToLevelUp = nextLevelXp.Value - playerXp.Value;

        while (amount >= xpNeededToLevelUp)
        {
            amount -= xpNeededToLevelUp;
            LevelUp();
            xpNeededToLevelUp = nextLevelXp.Value - playerXp.Value;
        }

        playerXp.Value += amount;
    }
}
