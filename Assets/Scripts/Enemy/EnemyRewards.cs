using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRewards : MonoBehaviour
{
    private GameObject player;
    private EnemyHealth enemyHealth;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
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
        player.GetComponent<PlayerLevel>().IncreaseXp(enemyStats.level * enemyStats.baseXpOnKill);
    }

    void DropRewards()
    {
        Debug.Log("Dropping rewards");
    }
}
