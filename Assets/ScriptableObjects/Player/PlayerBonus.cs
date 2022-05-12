using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerBonus : ScriptableObject
{
    public string Name;
    public PlayerBonusType Type;
    [SerializeField] private float initialValue;
    [SerializeField] private int points;
    [SerializeField] private float valueIncreasePerPoint;

    public float InitialValue
    {
        get { return initialValue; }
        set
        {
            initialValue = value;
            ValuesUpdated();
        }
    }

    public int Points
    {
        get { return points; }
        set
        {
            points = value;
            ValuesUpdated();
        }
    }

    public float ValueIncreasePerPoint
    {
        get { return valueIncreasePerPoint; }
        set
        {
            valueIncreasePerPoint = value;
            ValuesUpdated();
        }
    }

    public Action<float> OnValuesUpdate;

    public void ValuesUpdated()
    {
        float newValue = InitialValue + Points * ValueIncreasePerPoint;
        OnValuesUpdate?.Invoke(newValue);
    }
}
