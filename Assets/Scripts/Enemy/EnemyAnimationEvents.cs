using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    private EnemyAttack enemyAttack;

    void Start()
    {
        enemyAttack = transform.parent.GetComponent<EnemyAttack>();
    }
    
    public void TriggerAttack()
    {
        enemyAttack.Attack();
    }
}
