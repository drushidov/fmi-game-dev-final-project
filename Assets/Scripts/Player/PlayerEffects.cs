using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public Transform particlesOrigin;
    public GameObject healParticles;
    public Pickup healthPotionPickup;

    private PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        healthPotionPickup.OnUse += OnHeal;
    }

    private void OnDisable()
    {
        healthPotionPickup.OnUse -= OnHeal;
    }

    void OnHeal()
    {
        GameObject particles = Instantiate(healParticles, particlesOrigin);
        Destroy(particles, 2.0f);
    }
}
