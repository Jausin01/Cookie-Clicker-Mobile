using System;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static readonly int CurrencyCount = Enum.GetValues(typeof(CurrencyType)).Length;
    private readonly double[] points = new double[CurrencyCount];
    private readonly double[] pointsPerSecond = new double[CurrencyCount];

    public double PointsPerClick { get; private set; } = 1;

    public event Action OnEconomyChanged;

    public double Get(CurrencyType currency)
    {
        return points[(int)currency];
    }

    public double GetPerSecond(CurrencyType currency) 
    {
        return pointsPerSecond[(int)currency];
    }

    public void Add(CurrencyType currency, double amount)
    {
        points[(int)currency] += amount;
        OnEconomyChanged?.Invoke();
    }

    public bool TrySpend(CurrencyType currency, double cost)
    {
        if (points[(int)currency] < cost)
        {
            return false;
        }
        points[(int)currency] -= cost;
        OnEconomyChanged?.Invoke();
        return true;
    }

    public void AddPerSecond(CurrencyType currency, double amount)
    {
        pointsPerSecond[(int)currency] += amount;
        OnEconomyChanged?.Invoke();
    }

    public void AddPointsPerClick(double amount)
    {
        PointsPerClick += amount;
        OnEconomyChanged?.Invoke();
    }

}
