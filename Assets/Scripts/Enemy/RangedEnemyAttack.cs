using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : EnemyAttack
{
    public GameObject projectile;
    public Transform projectileSpawn;

    private EnemyStats enemyStats;

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    public override void Attack()
    {
        GameObject instantiatedProjectile = Instantiate(projectile, projectileSpawn.position, projectileSpawn.transform.rotation);
        instantiatedProjectile.GetComponent<EnemyProjectile>().SetDamage(enemyStats.GetDamage());
    }
}
