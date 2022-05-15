using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float value;
    public float Value
    {
        get { return value; }
        set
        {
            this.value = value;
            ValueChanged();
        }
    }

    public Action<float> OnValueChanged;

    public void ValueChanged()
    {
        OnValueChanged?.Invoke(Value);
    }
}
