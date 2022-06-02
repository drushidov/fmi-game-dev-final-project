using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSaving : MonoBehaviour
{
    public EnemyWaveManager waveManager;

    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerData lastSavedData;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        lastSavedData = SaveSystem.LoadPlayerData();

        if (lastSavedData != null)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            PlayerLevel playerLevel = player.GetComponent<PlayerLevel>();

            playerLevel.level.Value = lastSavedData.level;
            playerLevel.playerXp.Value = lastSavedData.xp;
            playerLevel.nextLevelXp.Value = lastSavedData.nextLevelXp;
            playerLevel.availableSkillPoints.Value = lastSavedData.availableSkillPoints;

            for (int i = 0; i < lastSavedData.bonuses.Count; i++)
            {
                PlayerBonus bonus = playerStats.playerBonuses[i];
                PlayerBonusData savedBonusData = lastSavedData.bonuses.Find(b => b.Name == bonus.Name);

                bonus.InitialValue = savedBonusData.InitialValue;
                bonus.ValueIncreasePerPoint = savedBonusData.ValueIncreasePerPoint;
                bonus.Points = savedBonusData.Points;
            }

            waveManager.SetBestWaveCount(lastSavedData.bestWaveCount);
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
        int currentSessionBestWaveCount = waveManager.GetBestWaveCount();
        int bestWaveCountToSave;

        if (lastSavedData == null || currentSessionBestWaveCount > lastSavedData.bestWaveCount)
        {
            bestWaveCountToSave = currentSessionBestWaveCount;
        } else
        {
            bestWaveCountToSave = lastSavedData.bestWaveCount;
        }

        lastSavedData = SaveSystem.SavePlayerData(player, bestWaveCountToSave);
    }
}
