using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SmoothSliderTransition : MonoBehaviour
{
    public Slider slider;
    public float transitionDuration = 1.0f;
    public float startValue = 0.0f;
    public float endValue = 1.0f;

    private Coroutine transitionCoroutine;

    public void StartTransition()
    {
        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        transitionCoroutine = StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            float currentValue = Mathf.Lerp(startValue, endValue, t);

            slider.value = currentValue;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        slider.value = endValue;
    }
}
