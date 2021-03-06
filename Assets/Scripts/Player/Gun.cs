using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;
    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void HideMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }

    public override void Use()
    {
        OnUse?.Invoke();
        muzzleFlash.SetActive(true);
        Invoke("HideMuzzleFlash", 0.1f);

        Quaternion bulletRotation = bulletSpawnPosition.transform.rotation;
        bulletRotation.x = 0;
        bulletRotation.z = 0;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletRotation);
        bullet.GetComponent<Bullet>().SetDamage(playerStats.GetDamage());
    }
}
