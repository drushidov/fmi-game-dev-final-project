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

    public GameObject playerLevelUpUI;
    public GameObject skillUpgradesUI;
    public GameObject skillUpgradeUI;

    private TextMeshProUGUI xpText;
    private PlayerBonus[] playerBonuses;

    private void Start()
    {
        xpText = GetComponent<TextMeshProUGUI>();
        xpText.text = "Player XP: " + playerXp.Value + ", Next Level XP: " + playerNextLevelXp.Value;
        playerBonuses = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().GetBonuses();

        GameObject skillUpgrade;

        foreach (PlayerBonus bonus in playerBonuses)
        {
            skillUpgrade = Instantiate(skillUpgradeUI, skillUpgradesUI.transform);
            skillUpgrade.GetComponent<SkillUpgrade>().SetBonus(bonus);
        }
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

        xpText.text = "Player XP: " + newXp + ", Next Level XP: " + playerNextLevelXp.Value;
    }

    void OnPlayerNextLevelXpChanged(int newNextLevelXp)
    {
        if (newNextLevelXp <= playerXp.Value)
        {
            // Prevent updating the UI while processing leveling up
            return;
        }

        xpText.text = "Player XP: " + playerXp.Value + ", Next Level XP: " + newNextLevelXp;
    }

    void OnPlayerLevelChanged(int newLevel)
    {
        playerLevelUpUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You reached Level " + playerLevel.Value + "! Available skill points: " + availableSkillPoints.Value;
        playerLevelUpUI.SetActive(true);
    }

    void OnAvailableSkillPointsChanged(int newValue)
    {
        if (newValue == 0)
        {
            playerLevelUpUI.SetActive(false);
        }
    }
}
