using UnityEngine;

[CreateAssetMenu(fileName = "CashPackData", menuName = "Scriptable Objects/CashPackData")]
public class CashPackData : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private double price = 0.99;
    [SerializeField] private CurrencyType currency;
    [SerializeField] private double amount = 100000;

    public string DisplayName => displayName;
    public double Price => price;
    public CurrencyType Currency => currency;
    public double Amount => amount;
}