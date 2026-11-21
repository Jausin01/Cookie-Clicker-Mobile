using UnityEngine;

public class UpgradeListBuilder : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;
    [SerializeField] private UpgradeButton upgradeButton;
    [SerializeField] private Transform content;
    [SerializeField] private UpgradeData[] upgrades;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        foreach (UpgradeData data in upgrades)
        {
            UpgradeButton row = Instantiate(upgradeButton, content);
            row.Setup(ecoManager, data);
            row.gameObject.SetActive(true);
        }
    }
}
