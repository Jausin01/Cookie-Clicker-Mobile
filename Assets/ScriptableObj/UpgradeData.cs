using System;
using UnityEngine;

public enum UpgradeType
{
    PerClick,
    PerSecond
}

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    [SerializeField] private string displayName;    
    [SerializeField] private UpgradeType upgradeType;    
    [SerializeField] private double bonus = 1;

    [SerializeField] private CostStage[] costStages;
    [SerializeField] private CurrencyType rewardCurrency = CurrencyType.Copper;

    public string DisplayName =>  displayName;
    public UpgradeType UpgradeType => upgradeType;
    public double Bonus => bonus;


    private CostStage GetStage(int level)
    {
        CostStage current = costStages[0];
        for (int i = 1; i < costStages.Length; i++)
        {
            if (costStages[i].FromLevel > level) break;
            current = costStages[i];
        }
        return current;
    }

    public double GetCost(int level)
    {
        CostStage stage = GetStage(level);
        return stage.GetCost(level - stage.FromLevel);
    }

    public CurrencyType GetCostCurrency(int level)
    {
        return GetStage(level).Currency;
    }


    public CurrencyType GetRewardCurrency(int level)
    {
        return rewardCurrency;
    }

}
