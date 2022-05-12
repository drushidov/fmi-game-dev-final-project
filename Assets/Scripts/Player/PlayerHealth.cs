using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float initialMaxHealth = 100.0f;
    private float maxHealth;
    private float currentHealth;
    private List<PlayerBonus> appliedBonuses;

    public Action<float, float> OnHealthChanged;
    public Action<float> OnMaxHealthChanged;
    public Action OnDeath;

    private void Awake()
    {
        maxHealth = initialMaxHealth;
        currentHealth = maxHealth;
        appliedBonuses = new List<PlayerBonus>();
    }

    public void CalculateMaxHealth(float bonus)
    {
        maxHealth = initialMaxHealth + bonus;
        OnMaxHealthChanged?.Invoke(maxHealth);
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(float damage)
    {
        float previousHealth = currentHealth;

        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        OnHealthChanged?.Invoke(previousHealth, currentHealth);

        Debug.Log("Player took " + damage + " damage");
    }

    public void Heal(float amount)
    {
        float previousHealth = currentHealth;

        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(previousHealth, currentHealth);
    }

    public void ApplyBonus(PlayerBonus bonus)
    {
        if (bonus.Type != PlayerBonusType.Health)
        {
            Debug.Log("Wrong bonus applied to player health");
            return;
        }

        appliedBonuses.Add(bonus);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}
