using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private float nearbyEnemiesAlertRadius = 7.0f;

    void Awake()
    {
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }

    public void PlayerDetected()
    {
        transform.parent.GetComponentInChildren<Animator>().SetBool("playerDetected", true);
    }

    public void AlertNearbyEnemiesForPlayer()
    {
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, nearbyEnemiesAlertRadius, LayerMask.GetMask("Enemy"));

        foreach (var enemyCollider in enemyColliders)
        {
            EnemyPlayerDetector enemyPlayerDetector = enemyCollider.gameObject.GetComponentInChildren<EnemyPlayerDetector>();

            if (enemyPlayerDetector != null)
            {
                enemyPlayerDetector.PlayerDetected();
            }
        }
    }

    private void OnEnable()
    {
        enemyHealth.OnDamageTaken += OnDamageTaken;
    }

    private void OnDisable()
    {
        enemyHealth.OnDamageTaken -= OnDamageTaken;
    }

    void OnDamageTaken(float damage, float currentHealth)
    {
        PlayerDetected();
        AlertNearbyEnemiesForPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected();
        }
    }
}
