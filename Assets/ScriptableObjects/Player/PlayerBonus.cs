using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerBonus : ScriptableObject
{
    public string Name;
    public PlayerBonusType Type;
    [SerializeField] private float InitialValue;
    [SerializeField] private int Points;
    [SerializeField] private float ValueIncreasePerPoint;

    public Action<float> OnValuesUpdate;

    public float GetInitialValue()
    {
        return InitialValue;
    }

    public int GetPoints()
    {
        return Points;
    }

    public float GetValueIncreasePerPoint()
    {
        return ValueIncreasePerPoint;
    }

    public void SetInitialValue(float value)
    {
        InitialValue = value;
        ValuesUpdated();
    }

    public void SetPoints(int points)
    {
        Points = points;
        ValuesUpdated();
    }

    public void SetValuePerPoint(float value)
    {
        ValueIncreasePerPoint = value;
        ValuesUpdated();
    }

    public void ValuesUpdated()
    {
        float newValue = InitialValue + Points * ValueIncreasePerPoint;
        OnValuesUpdate?.Invoke(newValue);
    }
}
