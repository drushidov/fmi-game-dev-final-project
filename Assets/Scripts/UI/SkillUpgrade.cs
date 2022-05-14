using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour
{
    public GameObject skillTextObject;
    public IntValue availableSkillPoints;

    private PlayerBonus bonus;

    void UpdateUI()
    {
        TextMeshProUGUI skillText = skillTextObject.GetComponent<TextMeshProUGUI>();
        skillText.text = bonus.Name + ": " + bonus.Points;
    }

    public void SetBonus(PlayerBonus bonus)
    {
        this.bonus = bonus;

        UpdateUI();
    }
    
    public void UpgradeSkill()
    {
        if (availableSkillPoints.Value <= 0)
        {
            return;
        }

        availableSkillPoints.Value--;
        bonus.Points++;

        TextMeshProUGUI skillText = skillTextObject.GetComponent<TextMeshProUGUI>();
        skillText.text = bonus.Name + ": " + bonus.Points;
    }
}
