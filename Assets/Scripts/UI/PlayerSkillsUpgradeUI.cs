using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSkillsUpgradeUI : MonoBehaviour
{
    public IntValue playerLevel;
    public IntValue availableSkillPoints;

    public GameObject playerLevelUpUI;
    public GameObject skillUpgradeUI;

    private PlayerBonus[] playerBonuses;

    private void Awake()
    {
        playerBonuses = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().GetBonuses();

        Transform skillUpgradesParent = playerLevelUpUI.transform.GetChild(1);
        GameObject newSkillUpgradeUI;

        foreach (PlayerBonus bonus in playerBonuses)
        {
            newSkillUpgradeUI = Instantiate(skillUpgradeUI, skillUpgradesParent);
            newSkillUpgradeUI.GetComponent<SkillUpgrade>().SetBonus(bonus);
        }
    }

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

    void OnPlayerLevelChanged(int newLevel)
    {
        playerLevelUpUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You reached Level " + newLevel + "! Available skill points: " + availableSkillPoints.Value;
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
