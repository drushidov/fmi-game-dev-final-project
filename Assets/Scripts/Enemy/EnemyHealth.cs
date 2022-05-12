using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;
    private float currentHealth;

    public Action<float, float> OnDamageTaken;
    public Action<float, float> OnHeal;
    public Action OnDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        OnDamageTaken?.Invoke(damage, currentHealth);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHeal?.Invoke(amount, currentHealth);
    }

    public void Die()
    {
        OnDeath?.Invoke();
    }
}
