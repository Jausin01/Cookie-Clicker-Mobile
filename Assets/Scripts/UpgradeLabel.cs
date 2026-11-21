using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(UpgradeButton))]
public class UpgradeLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text labelText;

    private Button button;
    private UpgradeButton upgradeButton;

    private void Awake()
    {
        button = GetComponent<Button>();
        upgradeButton = GetComponent<UpgradeButton>();
        
    }

    private void OnEnable()
    {
        upgradeButton.Economy.OnEconomyChanged += Refresh;
        upgradeButton.OnPurchase += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        upgradeButton.Economy.OnEconomyChanged -= Refresh;
        upgradeButton.OnPurchase -= Refresh;
    }

    private string BuildEffectText()
    {
        UpgradeData data = upgradeButton.Upgrade;
        double current = data.Bonus * upgradeButton.Level;
        string unit = data.UpgradeType == UpgradeType.PerClick ? "/click" : "/s";

        return "+" + current.ToString("0.##") + unit + " (next +" + data.Bonus.ToString("0.##") + ")";
    }

    private void Refresh()
    {
        double cost = upgradeButton.CurrentCost;
        CurrencyType currency = upgradeButton.CurrentCostCurrency;

        labelText.text = upgradeButton.Upgrade.DisplayName + " LVL: " + upgradeButton.Level + "\n" + BuildEffectText() + "\nCost: " + cost.ToString("N0") + " " + currency;


        button.interactable = upgradeButton.Economy.Get(currency) >= cost;
    }
}
