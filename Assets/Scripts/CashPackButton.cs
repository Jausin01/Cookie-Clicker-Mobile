using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CashPackButton : MonoBehaviour
{
    private EconomyManager ecoManager;
    private CashPackData pack;

    private Button button;

    public CashPackData Pack => pack;

    public void Setup(EconomyManager economy, CashPackData data)
    {
        ecoManager = economy;
        pack = data;
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
        ecoManager.Add(pack.Currency, pack.Amount);
    }
}