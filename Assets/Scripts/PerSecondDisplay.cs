using TMPro;
using UnityEngine;

public class PerSecondDisplay : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;
    [SerializeField] private TMP_Text perSecondText;
    [SerializeField] private CurrencyType currency;

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
        perSecondText.text = ecoManager.GetPerSecond(currency).ToString("0.##") + "/s";
    }
}
