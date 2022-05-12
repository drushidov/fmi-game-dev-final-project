using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float damage = 10.0f;
    public float maxAttackDistance = 3.0f;
    public float attackCooldown = 4.0f;

    private bool canAttack = true;

    public bool CanAttack()
    {
        return canAttack;
    }

    public void EnableAttack()
    {
        canAttack = true;
    }

    public void DisableAttack()
    {
        canAttack = false;
    }

    public void AttackPerformed()
    {
        DisableAttack();
        Invoke("EnableAttack", attackCooldown);
    }
}
