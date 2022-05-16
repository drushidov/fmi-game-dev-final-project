using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float baseDamage = 10.0f;
    private float damage;

    private PlayerHealth playerHealth;
    private Animator animator;

    public PlayerBonus[] playerBonuses;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponentInChildren<Animator>();

        damage = baseDamage;

        ProcessBonuses();
    }

    public float GetDamage()
    {
        return damage;
    }

    public PlayerBonus[] GetBonuses()
    {
        return playerBonuses;
    }

    public void ProcessBonuses()
    {
        foreach (PlayerBonus bonus in playerBonuses)
        {
            float valueToUpdate = bonus.InitialValue + (bonus.Points * bonus.ValueIncreasePerPoint);

            switch (bonus.Type)
            {
                case PlayerBonusType.Health:
                    playerHealth.ApplyMaxHealthBonus(bonus);
                    break;
                case PlayerBonusType.Damage:
                    OnDamageBonusUpdate(valueToUpdate);
                    bonus.OnValuesUpdate += OnDamageBonusUpdate;
                    break;
                case PlayerBonusType.Speed:
                    OnSpeedBonusUpdate(valueToUpdate);
                    bonus.OnValuesUpdate += OnSpeedBonusUpdate;
                    break;
            }
        }
    }

    public void OnDamageBonusUpdate(float newDamageBonus)
    {
        damage = baseDamage + newDamageBonus;
    }

    public void OnSpeedBonusUpdate(float newSpeedBonus)
    {
        animator.SetFloat("attackSpeedMultiplier", 1.0f + (newSpeedBonus / 100.0f));
    }
}
