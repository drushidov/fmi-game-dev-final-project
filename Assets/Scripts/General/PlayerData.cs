using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int xp;
    public int nextLevelXp;
    public int availableSkillPoints;
    public List<PlayerBonusData> bonuses;
}
