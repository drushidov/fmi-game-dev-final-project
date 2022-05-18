using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PickupController : MonoBehaviour
{
    public Pickup pickup;

    private void OnEnable()
    {
        pickup.OnUse += OnPickupUsed;
    }

    private void OnDisable()
    {
        pickup.OnUse -= OnPickupUsed;
    }

    protected abstract void OnPickupUsed();
}
