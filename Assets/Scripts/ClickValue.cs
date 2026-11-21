using UnityEngine;

public class ClickValue : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;
    [SerializeField] private DungeonManager dungeonManager;

    public double Value => ecoManager.PointsPerClick * dungeonManager.Active.ClickMultiplier;
    public CurrencyType Currency => dungeonManager.Active.Currency;
}
