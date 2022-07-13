using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static string saveFileName = "playerData.dat";

    public static PlayerData SavePlayerData(GameObject player, int bestWaveCount)
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        PlayerLevel playerLevel = player.GetComponent<PlayerLevel>();
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        PlayerData playerData = new PlayerData();

        playerData.level = playerLevel.level.Value;
        playerData.xp = playerLevel.playerXp.Value;
        playerData.nextLevelXp = playerLevel.nextLevelXp.Value;
        playerData.availableSkillPoints = playerLevel.availableSkillPoints.Value;

        playerData.bonuses = new List<PlayerBonusData>();

        foreach (PlayerBonus playerBonus in playerStats.GetBonuses())
        {
            PlayerBonusData playerBonusData = new PlayerBonusData();
            playerBonusData.Name = playerBonus.Name;
            playerBonusData.Type = playerBonus.Type;
            playerBonusData.InitialValue = playerBonus.InitialValue;
            playerBonusData.ValueIncreasePerPoint = playerBonus.ValueIncreasePerPoint;
            playerBonusData.Points = playerBonus.Points;

            playerData.bonuses.Add(playerBonusData);
        }

        playerData.bestWaveCount = bestWaveCount;

        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();

        return playerData;
    }

    public static PlayerData LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;

        if (File.Exists(filePath))
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            PlayerData playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;

            fileStream.Close();

            return playerData;
        } else
        {
            return null;
        }
    }

    public static void ClearPlayerData()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
