using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    public Transform effectsOrigin;
    public GameObject hurtParticles;

    private EnemyHealth health;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        health.OnDamageTaken += OnDamageTaken;
    }

    private void OnDisable()
    {
        health.OnDamageTaken -= OnDamageTaken;
    }

    void OnDamageTaken(float damage, float currentHealth)
    {
        GameObject instantiatedParticles = Instantiate(hurtParticles, effectsOrigin);

        Destroy(instantiatedParticles, 1.0f);
    }
}
