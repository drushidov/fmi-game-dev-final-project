using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRewards : MonoBehaviour
{
    public IntValue playerXp;
    private EnemyHealth enemyHealth;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        enemyHealth.OnDeath += RewardPlayerXP;
        enemyHealth.OnDeath += DropRewards;
    }

    private void OnDisable()
    {
        enemyHealth.OnDeath -= RewardPlayerXP;
        enemyHealth.OnDeath -= DropRewards;
    }

    void RewardPlayerXP()
    {
        EnemyStats enemyStats = GetComponent<EnemyStats>();
        playerXp.Value += enemyStats.level * enemyStats.baseXpOnKill;
    }

    void DropRewards()
    {
        Debug.Log("Dropping rewards");
    }
}
