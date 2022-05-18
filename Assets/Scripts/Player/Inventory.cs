using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Pickup, int> inventory;

    public static Inventory instance;

    public Action<Pickup> OnPickupAdded; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("More than one inventory instances exist");
        }

        inventory = new Dictionary<Pickup, int>();

        // Read inventory from a previously saved file
    }

    public void AddPickup(Pickup pickup)
    {
        if (inventory.ContainsKey(pickup))
        {
            inventory[pickup]++;
        }
        else
        {
            inventory[pickup] = 1;
        }

        OnPickupAdded?.Invoke(pickup);
    }
}
