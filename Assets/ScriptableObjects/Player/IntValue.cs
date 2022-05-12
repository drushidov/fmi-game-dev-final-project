using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntValue : ScriptableObject
{
    [SerializeField] private int value;
    public int Value
    {
        get {  return value; }
        set
        {
            this.value = value;
            ValueChanged();
        }
    }

    public Action<int> OnValueChanged;

    public void ValueChanged()
    {
        OnValueChanged?.Invoke(Value);
    }
}
