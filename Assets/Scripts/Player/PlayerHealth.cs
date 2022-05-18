using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float initialMaxHealth = 100.0f;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private List<PlayerBonus> appliedBonuses = new List<PlayerBonus>();

    public Action<float, float> OnHealthChanged;
    public Action<float> OnMaxHealthChanged;
    public Action OnDeath;

    private void Awake()
    {
        maxHealth = initialMaxHealth;
        currentHealth = maxHealth;

        OnHealthChanged?.Invoke(0f, currentHealth);
        OnMaxHealthChanged?.Invoke(maxHealth);
    }

    public void CalculateMaxHealth()
    {
        float bonusHealth = 0f;

        foreach (PlayerBonus bonus in appliedBonuses)
        {
            bonusHealth += bonus.InitialValue + ((bonus.Points * 1.0f) * bonus.ValueIncreasePerPoint);
        }

        float previousMaxHealth = maxHealth;

        maxHealth = initialMaxHealth + bonusHealth;

        if (currentHealth == previousMaxHealth)
        {
            // If the player was at max health, set the current health to the max again
            currentHealth = maxHealth;
        }


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

    public void ApplyMaxHealthBonus(PlayerBonus newBonus)
    {
        if (newBonus.Type != PlayerBonusType.Health)
        {
            Debug.Log("Wrong bonus applied to player max health");
            return;
        }

        if (appliedBonuses.Find((bonus) => bonus.Name == newBonus.Name))
        {
            Debug.Log("Applied bonus " + newBonus.Name + " twice");
            return;
        }

        appliedBonuses.Add(newBonus);
        newBonus.OnValuesUpdate += (newValue) => CalculateMaxHealth();

        CalculateMaxHealth();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}
