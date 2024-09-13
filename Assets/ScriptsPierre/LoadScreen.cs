using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public static LoadScreen instance;
    [SerializeField] private float _fadeDuration = 1f;

    private CanvasGroup _canvasGroup;

    public void FadeA() => StartCoroutine(FadeIn());

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void StartLoadScreen()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return StartCoroutine(FadeIn());

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        _canvasGroup.blocksRaycasts = true; 
        float elapsedTime = 0f;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / _fadeDuration);
            _canvasGroup.alpha = alpha;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1f - (elapsedTime / _fadeDuration));
            _canvasGroup.alpha = alpha;
            yield return null;
        }

        _canvasGroup.blocksRaycasts = false;
    }
}
