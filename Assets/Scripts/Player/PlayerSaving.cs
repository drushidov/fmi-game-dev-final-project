using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaving : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();

        PlayerData savedPlayerData = SaveSystem.LoadPlayerData();

        if (savedPlayerData != null)
        {
            PlayerStats playerStats = GetComponent<PlayerStats>();
            PlayerLevel playerLevel = GetComponent<PlayerLevel>();

            playerLevel.level.Value = savedPlayerData.level;
            playerLevel.playerXp.Value = savedPlayerData.xp;
            playerLevel.nextLevelXp.Value = savedPlayerData.nextLevelXp;
            playerLevel.availableSkillPoints.Value = savedPlayerData.availableSkillPoints;

            for (int i = 0; i < savedPlayerData.bonuses.Count; i++)
            {
                PlayerBonus bonus = playerStats.playerBonuses[i];
                PlayerBonusData savedBonusData = savedPlayerData.bonuses.Find(b => b.Name == bonus.Name);

                bonus.InitialValue = savedBonusData.InitialValue;
                bonus.ValueIncreasePerPoint = savedBonusData.ValueIncreasePerPoint;
                bonus.Points = savedBonusData.Points;
            }
        }
    }

    private void OnEnable()
    {
        playerHealth.OnDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        SaveSystem.SavePlayerData(gameObject);
    }
}
