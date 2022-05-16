using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    private GameObject player;
    private EnemyController enemyController;
    private EnemyStats enemyStats;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyController = transform.parent.GetComponent<EnemyController>();
        enemyStats = transform.parent.GetComponent<EnemyStats>();
    }
    
    public void DamagePlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= enemyController.maxAttackDistance)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            playerHealth.TakeDamage(enemyStats.GetDamage());
        }
    }
}
