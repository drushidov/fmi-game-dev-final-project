using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSkillsUpgradeUI : MonoBehaviour
{
    public IntValue playerLevel;
    public IntValue availableSkillPoints;

    public GameObject playerSkillsMenu;
    public GameObject skillUpgradeUI;
    public TextMeshProUGUI availableSkillPointsText;

    private PlayerBonus[] playerBonuses;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerBonuses = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().GetBonuses();

        Transform skillUpgradesParent = playerSkillsMenu.transform.GetChild(1);
        GameObject newSkillUpgradeUI;

        foreach (PlayerBonus bonus in playerBonuses)
        {
            newSkillUpgradeUI = Instantiate(skillUpgradeUI, skillUpgradesParent);
            newSkillUpgradeUI.GetComponent<SkillUpgrade>().SetBonus(bonus);
        }

        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerLevel.OnValueChanged += OnPlayerLevelChanged;
        availableSkillPoints.OnValueChanged += OnAvailableSkillPointsChanged;
        playerInputActions.Enable();
        playerInputActions.Player.SkillsMenuTrigger.performed += TriggerSkillsMenu;
    }

    private void OnDisable()
    {
        playerLevel.OnValueChanged -= OnPlayerLevelChanged;
        availableSkillPoints.OnValueChanged -= OnAvailableSkillPointsChanged;
        playerInputActions.Player.SkillsMenuTrigger.performed -= TriggerSkillsMenu;
        playerInputActions.Disable();
    }

    void OnPlayerLevelChanged(int newLevel)
    {
        availableSkillPointsText.text = "You reached Level " + newLevel + "! Available skill points: " + availableSkillPoints.Value;
        playerSkillsMenu.SetActive(true);
    }

    void OnAvailableSkillPointsChanged(int newValue)
    {
        if (newValue == 0)
        {
            playerSkillsMenu.SetActive(false);
        }
    }

    private void TriggerSkillsMenu(InputAction.CallbackContext context)
    {
        playerSkillsMenu.SetActive(!playerSkillsMenu.activeSelf);

        if (!playerSkillsMenu.activeSelf)
        {
            // Closed the skills menu, no need to update
            return;
        }

        int currentAvailablePoints = availableSkillPoints.Value;
        Transform skillUpgradesParent = playerSkillsMenu.transform.GetChild(1);

        if (currentAvailablePoints == 0)
        {
            availableSkillPointsText.text = "You don't have any available skill points.";

            for (int i = 0; i < skillUpgradesParent.childCount; i++)
            {
                Button skillUpgradeBtn = skillUpgradesParent.GetChild(i).GetComponentInChildren<Button>();

                if (skillUpgradeBtn != null)
                {
                    skillUpgradeBtn.interactable = false;
                }
            }
        } else
        {
            availableSkillPointsText.text = "You have " + currentAvailablePoints + " available skill ";

            if (currentAvailablePoints == 1)
            {
                availableSkillPointsText.text += "point.";
            } else
            {
                availableSkillPointsText.text += "points.";
            }

            for (int i = 0; i < skillUpgradesParent.childCount; i++)
            {
                Button skillUpgradeBtn = skillUpgradesParent.GetChild(i).GetComponentInChildren<Button>();

                if (skillUpgradeBtn != null)
                {
                    skillUpgradeBtn.interactable = true;
                }
            }
        }
    }
}
