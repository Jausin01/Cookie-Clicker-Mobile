using UnityEngine;

[CreateAssetMenu(fileName = "DungeonData", menuName = "Scriptable Objects/DungeonData")]
public class DungeonData : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private CurrencyType currency;
    [SerializeField] private double clickMultiplier = 1;

    public string DisplayName => displayName;
    public CurrencyType Currency => currency;
    public double ClickMultiplier => clickMultiplier;
}
