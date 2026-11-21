using UnityEngine;
using TMPro;

[RequireComponent(typeof(CashPackButton))]
public class CashPackLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text labelText;

    private CashPackButton packButton;

    private void Awake()
    {
        packButton = GetComponent<CashPackButton>();
    }

    private void OnEnable()
    {
        Refresh();
    }

    private void Refresh()
    {
        CashPackData pack = packButton.Pack;

        labelText.text = pack.DisplayName + "\n" + pack.Amount.ToString("N0") + " " + pack.Currency + "\n$" + pack.Price.ToString("0.00");
    }
}