using TMPro;
using UnityEngine;

public class ClickValueDisplay : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;
    [SerializeField] private DungeonManager dungeonManager;
    [SerializeField] private ClickValue clickValue;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private CurrencyType currency;
    private void OnEnable()
    {
        ecoManager.OnEconomyChanged += Refresh;
        dungeonManager.OnDungeonChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        ecoManager.OnEconomyChanged -= Refresh;
        dungeonManager.OnDungeonChanged -= Refresh;
    }

    private void Refresh()
    {
        bool isActive = dungeonManager.Active.Currency == currency;
        valueText.text = isActive ? "+" + clickValue.Value.ToString("0.##") + "/click" : "";
    }

}
