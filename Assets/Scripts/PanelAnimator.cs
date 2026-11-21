using System.Collections;
using UnityEngine;

public class PanelAnimator : MonoBehaviour
{
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private Vector2 slideOffset = new Vector2(1200, 0);

    private RectTransform rectTransform;
    private Vector2 restPosition;
    private Coroutine running;
    private float progress;

    private void Awake()
    {
        rectTransform = (RectTransform)transform;
        restPosition = rectTransform.anchoredPosition;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Play(1f);
    }

    public void Close()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }

        Play(0f);
    }

    private void Play(float target)
    {
        if (running != null)
        {
            StopCoroutine(running);
        }

        running = StartCoroutine(Animate(target));
    }

    private IEnumerator Animate(float target)
    {
        while (!Mathf.Approximately(progress, target))
        {
            progress = Mathf.MoveTowards(progress, target, Time.unscaledDeltaTime / duration);
            Apply();
            yield return null;
        }

        running = null;

        if (target == 0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void Apply()
    {
        float eased = Mathf.SmoothStep(0f, 1f, progress);
        rectTransform.anchoredPosition = restPosition + slideOffset * (1f - eased);
    }
}