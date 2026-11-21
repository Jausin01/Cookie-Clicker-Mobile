using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelButton : MonoBehaviour
{
    [SerializeField] private GameObject targetPanel;
    [SerializeField] private bool showPanel;

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
        PanelAnimator animator = targetPanel.GetComponent<PanelAnimator>();

        if (animator == null)
        {
            targetPanel.SetActive(showPanel);
            return;
        }

        if (showPanel)
        {
            animator.Open();
        }
        else
        {
            animator.Close();
        }
    }

}
