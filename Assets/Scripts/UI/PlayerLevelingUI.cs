using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelingUI : MonoBehaviour
{
    public IntValue playerXp;
    public IntValue playerNextLevelXp;
    public IntValue playerLevel;
    public IntValue availableSkillPoints;

    public Slider xpBarSlider;
    public GameObject levelTextObject;
    public GameObject skillPointsTextObject;

    public GameObject playerLevelUpUI;
    public GameObject skillUpgradesUI;
    public GameObject skillUpgradeUI;

    private TextMeshProUGUI levelText;
    private TextMeshProUGUI skillPointsText;

    private PlayerBonus[] playerBonuses;

    private void Awake()
    {
        levelText = levelTextObject.GetComponent<TextMeshProUGUI>();
        skillPointsText = skillPointsTextObject.GetComponent<TextMeshProUGUI>();

        playerBonuses = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().GetBonuses();

        GameObject skillUpgrade;

        foreach (PlayerBonus bonus in playerBonuses)
        {
            skillUpgrade = Instantiate(skillUpgradeUI, skillUpgradesUI.transform);
            skillUpgrade.GetComponent<SkillUpgrade>().SetBonus(bonus);
        }

        UpdateSlider();
    }

    private void OnEnable()
    {
        playerXp.OnValueChanged += OnPlayerXpChanged;
        playerNextLevelXp.OnValueChanged += OnPlayerNextLevelXpChanged;
        playerLevel.OnValueChanged += OnPlayerLevelChanged;
        availableSkillPoints.OnValueChanged += OnAvailableSkillPointsChanged;
    }

    private void OnDisable()
    {
        playerXp.OnValueChanged -= OnPlayerXpChanged;
        playerNextLevelXp.OnValueChanged -= OnPlayerNextLevelXpChanged;
        playerLevel.OnValueChanged -= OnPlayerLevelChanged;
        availableSkillPoints.OnValueChanged -= OnAvailableSkillPointsChanged;
    }

    void OnPlayerXpChanged(int newXp)
    { 
        if (newXp >= playerNextLevelXp.Value)
        {
            // Prevent updating the UI while processing leveling up
            return;
        }

        UpdateSlider();
    }

    void OnPlayerNextLevelXpChanged(int newNextLevelXp)
    {
        if (newNextLevelXp <= playerXp.Value)
        {
            // Prevent updating the UI while processing leveling up
            return;
        }

        UpdateSlider();
    }

    void OnPlayerLevelChanged(int newLevel)
    {
        levelText.text = "Level: " + newLevel;

        playerLevelUpUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You reached Level " + newLevel + "! Available skill points: " + availableSkillPoints.Value;
        playerLevelUpUI.SetActive(true);
    }

    void OnAvailableSkillPointsChanged(int newValue)
    {
        skillPointsText.text = "Available Skill Points: " + newValue;

        if (newValue == 0)
        {
            playerLevelUpUI.SetActive(false);
        }
    }

    void UpdateSlider()
    {
        float sliderValue = (playerXp.Value * 1.0f) / (playerNextLevelXp.Value * 1.0f);
        xpBarSlider.value = sliderValue;
    }
}
