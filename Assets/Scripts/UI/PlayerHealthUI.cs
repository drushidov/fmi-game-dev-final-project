using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider healthBarSlider;

    void Start()
    {
        UpdateHealthBar();
    }

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnMaxHealthChanged += OnMaxHealthChanged;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= OnHealthChanged;
        playerHealth.OnMaxHealthChanged -= OnMaxHealthChanged;
    }

    void OnHealthChanged(float previousHealth, float currentHealth)
    {
        UpdateHealthBar();
    }

    void OnMaxHealthChanged(float currentMaxHealth)
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBarSlider.value = playerHealth.GetHealth() / playerHealth.GetMaxHealth();
    }
}
