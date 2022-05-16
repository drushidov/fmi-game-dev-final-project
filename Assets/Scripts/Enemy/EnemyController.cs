using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxAttackDistance = 3.0f;
    public float attackCooldown = 4.0f;

    private bool canAttack = true;

    private Animator animator;
    private GameObject player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private EnemyStats enemyStats;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyStats = GetComponent<EnemyStats>();
    }

    private void OnEnable()
    {
        playerHealth.OnDeath += OnPlayerDeath;
        enemyHealth.OnDeath += OnDeath;
        enemyStats.OnLevelChanged += OnLevelChanged;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= OnPlayerDeath;
        enemyHealth.OnDeath -= OnDeath;
        enemyStats.OnLevelChanged -= OnLevelChanged;
    }

    private void OnPlayerDeath()
    {
        animator.SetBool("playerDetected", false);
        animator.SetTrigger("playerDied");
    }

    private void OnDeath()
    {
        animator.SetBool("dead", true);
    }

    private void OnLevelChanged(int newLevel)
    {
        enemyHealth.SetMaxHealth(enemyHealth.baseMaxHealth + enemyStats.GetHealthBonus());
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
