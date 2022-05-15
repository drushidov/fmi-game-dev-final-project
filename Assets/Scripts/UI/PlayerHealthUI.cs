using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public GameObject player;
    public Slider healthBarSlider;

    private PlayerHealth playerHealth;

    private float currentPlayerHealth;
    private float maxPlayerHealth;

    private void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        currentPlayerHealth = playerHealth.GetHealth();
        maxPlayerHealth = playerHealth.GetMaxHealth();
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
        currentPlayerHealth = currentHealth;
        UpdateHealthBar();
    }

    void OnMaxHealthChanged(float currentMaxHealth)
    {
        maxPlayerHealth = currentMaxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBarSlider.value = currentPlayerHealth / maxPlayerHealth;
    }
}
