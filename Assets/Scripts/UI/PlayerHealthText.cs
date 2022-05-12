using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthText : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth playerHealth;
    public TextMeshProUGUI playerHealthText;

    void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealthText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        playerHealthText.text = "Player Health: " + playerHealth.GetHealth() + ", Max Health: " + playerHealth.GetMaxHealth();
    }

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += OnPlayerHealthChanged;
        playerHealth.OnMaxHealthChanged += OnPlayerMaxHealthChanged;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= OnPlayerHealthChanged;
        playerHealth.OnMaxHealthChanged -= OnPlayerMaxHealthChanged;
    }

    public void OnPlayerHealthChanged(float previousHealth, float currentHealth)
    {
        playerHealthText.text = "Player Health: " + currentHealth + ", Max Health: " + playerHealth.GetMaxHealth();
    }

    public void OnPlayerMaxHealthChanged(float newMaxHealth)
    {
        playerHealthText.text = "Player Health: " + playerHealth.GetHealth() + ", Max Health: " + newMaxHealth;
    }

    public void IncreaseHealth()
    {
        foreach (PlayerBonus playerBonus in player.GetComponent<PlayerStats>().GetBonuses())
        {
            if (playerBonus.Type == PlayerBonusType.Health)
            {
                playerBonus.Points++;
                break;
            }
        }
    }
}
