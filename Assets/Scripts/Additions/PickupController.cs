using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PickupController : MonoBehaviour
{
    [SerializeField] protected Pickup pickup;

    public abstract void UsePickup();
}
