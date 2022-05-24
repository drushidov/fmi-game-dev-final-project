using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    void Awake()
    {
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();
    }

    public void PlayerDetected()
    {
        transform.parent.GetComponentInChildren<Animator>().SetBool("playerDetected", true);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected();
        }
    }
}
