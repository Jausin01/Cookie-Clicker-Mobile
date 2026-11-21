using System;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] private DungeonData startingDungeon;

    private DungeonData current;

    public DungeonData Active => current != null ? current : startingDungeon;

    public event Action OnDungeonChanged;


    public void SetActive(DungeonData dungeon)
    {
        if (dungeon == null || dungeon == Active)
        {
            return;
        }

        current = dungeon;
        OnDungeonChanged?.Invoke();

    }
}
