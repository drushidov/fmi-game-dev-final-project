using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Pickup : ScriptableObject
{
    public string Name;
    public Image Image;

    public Action OnUse;

    public void Use()
    {
        OnUse?.Invoke();
    }
}
