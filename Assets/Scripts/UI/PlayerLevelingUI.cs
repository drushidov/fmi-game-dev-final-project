using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLevelingUI : MonoBehaviour
{
    public IntValue playerXp;
    public IntValue playerNextLevelXp;

    private TextMeshProUGUI xpText;

    private void Start()
    {
        xpText = GetComponent<TextMeshProUGUI>();
        xpText.text = "Player XP: " + playerXp.Value + ", Next Level XP: " + playerNextLevelXp.Value;
    }

    private void OnEnable()
    {
        playerXp.OnValueChanged += OnPlayerXpChanged;
        playerNextLevelXp.OnValueChanged += OnPlayerNextLevelXpChanged;
    }

    private void OnDisable()
    {
        playerXp.OnValueChanged -= OnPlayerXpChanged;
        playerNextLevelXp.OnValueChanged -= OnPlayerNextLevelXpChanged;
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
}
