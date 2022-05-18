using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRewards : MonoBehaviour
{
    public IntValue playerXp;

    private EnemyHealth enemyHealth;
    private EnemyStats enemyStats;
    private EnemyDrops enemyDrops;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyStats = GetComponent<EnemyStats>();
        enemyDrops = GetComponent<EnemyDrops>();
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
        playerXp.Value += enemyStats.GetXpOnKill();
    }

    void DropRewards()
    {
        enemyDrops.RollDropTable();
    }
}
