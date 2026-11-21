using UnityEngine;
using System;

[Serializable]
public class CostStage
{
    [SerializeField] private int fromLevel;
    [SerializeField] private CurrencyType currency;
    [SerializeField] private double baseCost = 10;
    [SerializeField] private double costMultiplier = 1.15;

    public int FromLevel => fromLevel;
    public CurrencyType Currency => currency;

    public double GetCost(int levelInStage)
    {
        return Math.Floor(baseCost * Math.Pow(costMultiplier, levelInStage));
    }
}
