using TMPro;
using UnityEngine;

public class PlayerLevelingUI : MonoBehaviour
{
    public IntValue playerLevel;
    public IntValue availableSkillPoints;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI skillPointsText;

    private void OnEnable()
    {
        
        playerLevel.OnValueChanged += OnPlayerLevelChanged;
        availableSkillPoints.OnValueChanged += OnAvailableSkillPointsChanged;
    }

    private void OnDisable()
    {
        playerLevel.OnValueChanged -= OnPlayerLevelChanged;
        availableSkillPoints.OnValueChanged -= OnAvailableSkillPointsChanged;
    }

    private void Start()
    {
        OnPlayerLevelChanged(playerLevel.Value);
        OnAvailableSkillPointsChanged(availableSkillPoints.Value);
    }

    void OnPlayerLevelChanged(int newLevel)
    {
        levelText.text = "Level: " + newLevel;
    }

    void OnAvailableSkillPointsChanged(int newValue)
    {
        skillPointsText.text = "Available Skill Points: " + newValue;
    }
}
