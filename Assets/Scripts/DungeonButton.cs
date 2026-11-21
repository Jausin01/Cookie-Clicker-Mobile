using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class DungeonButton : MonoBehaviour
{
    [SerializeField] private DungeonManager dungeonManager;
    [SerializeField] private DungeonData dungeon;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(HandleClick);
    }

    private void HandleClick()
    {
        dungeonManager.SetActive(dungeon);
    }


}
