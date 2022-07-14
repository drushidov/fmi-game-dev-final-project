using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public Transform particlesOrigin;
    public GameObject healParticles;
    public Pickup healthPotionPickup;

    private PlayerHealth playerHealth;
    private PlayerHitEffect playerHitTintEffect;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHitTintEffect = Camera.main.GetComponent<PlayerHitEffect>();
    }

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        healthPotionPickup.OnUse += OnHeal;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= OnHealthChanged;
        healthPotionPickup.OnUse -= OnHeal;
    }

    private void OnHealthChanged(float previousHealth, float currentHealth)
    {
        if (previousHealth <= currentHealth)
        {
            return;
        }

        StartCoroutine(TintScreen(playerHitTintEffect));
    }

    IEnumerator TintScreen(PlayerHitEffect hitEffectComponent)
    {
        float transitionDuration = 0.2f;
        float tintStrength = 0;

        while (tintStrength < 1)
        {
            hitEffectComponent.playerHitMaterial.SetFloat("_TintStrength", tintStrength);
            tintStrength += Time.deltaTime / transitionDuration;
            yield return null;
        }

        while (tintStrength > 0)
        {
            hitEffectComponent.playerHitMaterial.SetFloat("_TintStrength", tintStrength);
            tintStrength -= Time.deltaTime / transitionDuration;
            yield return null;
        }

        // The last value set for tint strength is likely greater than 0, so we zero it out here
        hitEffectComponent.playerHitMaterial.SetFloat("_TintStrength", 0);
        yield return null;
    }

    void OnHeal()
    {
        GameObject particles = Instantiate(healParticles, particlesOrigin);
        Destroy(particles, 2.0f);
    }
}
