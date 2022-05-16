using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private int baseXpOnKill;
    [SerializeField] private int xpBonusPerLevel;
    [SerializeField] private float healthBonusPerLevel;
    [SerializeField] private float baseDamage;
    [SerializeField] private float damageBonusPerLevel;

    public Action<int> OnLevelChanged;

    public void SetLevel(int level)
    {
        this.level = level;

        OnLevelChanged?.Invoke(level);
    }

    public int GetXpOnKill()
    {
        return baseXpOnKill + (level * xpBonusPerLevel);
    }

    public float GetHealthBonus()
    {
        return level * healthBonusPerLevel;
    }

    public float GetDamage()
    {
        return baseDamage + ((level * 1.0f) * damageBonusPerLevel);
    }
}
