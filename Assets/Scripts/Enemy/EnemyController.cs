using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float damage = 10.0f;
    public float maxAttackDistance = 3.0f;
    public float attackCooldown = 4.0f;

    private bool canAttack = true;

    private Animator animator;
    private GameObject player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        playerHealth.OnDeath += OnPlayerDeath;
        enemyHealth.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= OnPlayerDeath;
        enemyHealth.OnDeath -= OnDeath;
    }

    private void OnPlayerDeath()
    {
        animator.SetBool("playerDetected", false);
        animator.SetTrigger("playerDied");
    }

    private void OnDeath()
    {

        animator.SetTrigger("die");
    }

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
