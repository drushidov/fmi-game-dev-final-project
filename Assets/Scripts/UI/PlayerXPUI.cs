using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXPUI : MonoBehaviour
{
    public IntValue playerXp;
    public IntValue playerNextLevelXp;

    public Slider xpBarSlider;

    private void Start()
    {
        UpdateXpBar();
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

        UpdateXpBar();
    }

    void OnPlayerNextLevelXpChanged(int newNextLevelXp)
    {
        if (newNextLevelXp <= playerXp.Value)
        {
            // Prevent updating the UI while processing leveling up
            return;
        }

        UpdateXpBar();
    }

    void UpdateXpBar()
    {
        float sliderValue = (playerXp.Value * 1.0f) / (playerNextLevelXp.Value * 1.0f);
        xpBarSlider.value = sliderValue;
    }
}
