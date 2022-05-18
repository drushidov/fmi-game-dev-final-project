using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionController : PickupController
{
    public float healPercentage;

    public override void UsePickup()
    {
        PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.Heal(playerHealth.GetMaxHealth() * (healPercentage / 100.0f));
        pickup.HandleUse();
    }
}
