using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    private bool isCoroutineRunning = false;

    public void Setup()
    {
        if (!isCoroutineRunning)
        {
            gameObject.SetActive(true); 
            StartCoroutine(SlowTimeScaleAndGameOver());
        }
    }

    IEnumerator SlowTimeScaleAndGameOver()
    {
        isCoroutineRunning = true;
        float duration = 2.0f;
        float startValue = Time.timeScale;
        float endValue = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            yield return null;
        }

        Time.timeScale = 0f;
        isCoroutineRunning = false;
    }
}
