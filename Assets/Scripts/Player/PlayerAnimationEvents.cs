using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Weapon playerWeapon;

    void Start()
    {
        playerWeapon = transform.parent.GetComponent<Weapon>();
    }

    public void UsePlayerWeapon()
    {
        playerWeapon.Use();
    }
}
