using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02_SetUpScript : MonoBehaviour
{
    public float waitTime = 2.0f; // Time to wait before starting the fade
    public float fadeDuration = 1.0f; // Duration of the fade

    private CanvasGroup canvasGroup;
    private float timer = 0.0f;
    private bool isFading = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component is missing.");
            return;
        }

        canvasGroup.alpha = 0.0f; // Start fully transparent
    }

    void Update()
    {
        if (!isFading)
        {
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                StartCoroutine(FadeIn());
                isFading = true;
            }
        }
    }

    private IEnumerator FadeIn()
    {
        float fadeTimer = 0.0f;

        while (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1.0f; // Ensure the alpha is set to fully opaque
    }
}
