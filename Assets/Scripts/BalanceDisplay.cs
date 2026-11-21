using UnityEngine;
using System;
using TMPro;


public class BalanceDisplay : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;
    [SerializeField] private CurrencyType currency;
    [SerializeField] private TMP_Text balanceText;

    private void OnEnable()
    {
        ecoManager.OnEconomyChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        ecoManager.OnEconomyChanged -= Refresh;
    }

    private void Refresh()
    {
        balanceText.text = Math.Floor(ecoManager.Get(currency)).ToString();
    }

}