using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffects : MonoBehaviour
{
    public AudioClip gunshotAudioClip;

    private AudioSource audioSource;
    private Weapon playerWeapon;

    void Awake()
    {
        playerWeapon = GetComponent<Weapon>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        playerWeapon.OnUse += OnWeaponUse;
    }

    private void OnDisable()
    {
        playerWeapon.OnUse -= OnWeaponUse;
    }

    void OnWeaponUse()
    {
        audioSource.clip = gunshotAudioClip;
        audioSource.Play();
    }
}
