using UnityEngine;

public class CashPackListBuilder : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;
    [SerializeField] private CashPackButton packButton;
    [SerializeField] private Transform content;
    [SerializeField] private CashPackData[] packs;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        foreach (CashPackData data in packs)
        {
            CashPackButton item = Instantiate(packButton, content);
            item.Setup(ecoManager, data);
            item.gameObject.SetActive(true);
        }
    }
}