using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class UpgradeButton : MonoBehaviour
{
    private EconomyManager ecoManager;
    private UpgradeData upgrade;

    private Button button;

    public EconomyManager Economy => ecoManager;
    public UpgradeData Upgrade => upgrade;
    public int Level { get; private set; }
    public double CurrentCost => upgrade.GetCost(Level);
    public CurrencyType CurrentCostCurrency => upgrade.GetCostCurrency(Level);

    public event Action OnPurchase;

    public void Setup(EconomyManager economy, UpgradeData data)
    {
        ecoManager = economy;
        upgrade = data;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(HandlePurchase);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(HandlePurchase);
    }

    private void HandlePurchase()
    {
        if (!ecoManager.TrySpend(CurrentCostCurrency, CurrentCost))
        {
            return;
        }

        ApplyBonus();
        Level++;
        OnPurchase?.Invoke();
    }

    private void ApplyBonus()
    {
        switch (upgrade.UpgradeType)
        {
            case UpgradeType.PerClick:
                ecoManager.AddPointsPerClick(upgrade.Bonus);
                break;
            case UpgradeType.PerSecond:
                ecoManager.AddPerSecond(upgrade.GetRewardCurrency(Level),upgrade.Bonus);
                break;
        }
    }
}