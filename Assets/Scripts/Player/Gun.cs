using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;

    public override void Use()
    {
        Quaternion bulletRotation = bulletSpawnPosition.transform.rotation;
        bulletRotation.x = 0;
        bulletRotation.z = 0;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletRotation);

    }
}
