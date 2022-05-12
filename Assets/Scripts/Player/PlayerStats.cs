using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float baseDamage = 10.0f;
    private float damage;
    [SerializeField] private float movementSpeed = 1.0f;

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

    // Update is called once per frame
    void Update()
    {
        
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
            switch (bonus.Type)
            {
                case PlayerBonusType.Health:
                    OnHealthBonusUpdate(bonus.GetInitialValue() + (bonus.GetPoints() * bonus.GetValueIncreasePerPoint()));
                    bonus.OnValuesUpdate += OnHealthBonusUpdate;
                    break;
                case PlayerBonusType.Damage:
                    OnDamageBonusUpdate(bonus.GetInitialValue() + (bonus.GetPoints() * bonus.GetValueIncreasePerPoint()));
                    break;
                case PlayerBonusType.Speed:
                    OnSpeedBonusUpdate(bonus.GetInitialValue() + (bonus.GetPoints() * bonus.GetValueIncreasePerPoint()));
                    break;
            }
        }
    }

    public void OnDamageBonusUpdate(float newDamageBonus)
    {
        damage = baseDamage + newDamageBonus;
    }

    public void OnHealthBonusUpdate(float newHealthBonus)
    {
        playerHealth.CalculateMaxHealth(newHealthBonus);
    }

    public void OnSpeedBonusUpdate(float newSpeedBonus)
    {
        animator.SetFloat("attackSpeedMultiplier", 1.0f + (newSpeedBonus / 100.0f));
    }
}
