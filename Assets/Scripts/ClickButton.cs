using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickButton : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;
    [SerializeField] private ClickValue clickValue;

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
        ecoManager.Add(clickValue.Currency, clickValue.Value);
    }
}
