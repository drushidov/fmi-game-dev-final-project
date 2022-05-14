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

    private void OnEnable()
    {
        playerXp.OnValueChanged += OnXpValueChanged;
    }

    private void OnDisable()
    {
        playerXp.OnValueChanged -= OnXpValueChanged;
    }

    private void LevelUp()
    {
        level.Value++;
        availableSkillPoints.Value++;

        playerXp.Value = 0;
        nextLevelXp.Value *= 2;
    }

    private void OnXpValueChanged(int newValue)
    {
        int playerXpValue = playerXp.Value;

        // To prevent constant triggering of this method by setting the playerXp.Value,
        // if the XP is not enough to level up, return
        if (playerXpValue < nextLevelXp.Value)
        {
            return;
        }

        while (playerXpValue >= nextLevelXp.Value)
        {
            playerXpValue -= nextLevelXp.Value;
            LevelUp();
        }

        playerXp.Value = playerXpValue;
    }
}
