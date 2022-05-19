using UnityEngine;

public class MeleeEnemyAttack : EnemyAttack
{
    private GameObject player;
    private EnemyController enemyController;
    private EnemyStats enemyStats;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyController = GetComponent<EnemyController>();
        enemyStats = GetComponent<EnemyStats>();
    }

    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= enemyController.maxAttackDistance)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            playerHealth.TakeDamage(enemyStats.GetDamage());
        }
    }
}
