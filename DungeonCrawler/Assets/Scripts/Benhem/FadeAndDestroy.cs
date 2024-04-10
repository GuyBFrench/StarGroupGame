using UnityEngine;
using UnityEngine.Events;

public class FadeAndDestroy : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration of fade in seconds
    public UnityEvent onDestroyEvent; // UnityEvent to trigger when object is destroyed

    private Renderer[] childRenderers;
    private Color[] initialColors;

    private void Start()
    {
        // Get all child renderers
        childRenderers = GetComponentsInChildren<Renderer>();

        // Store initial colors of all child renderers
        initialColors = new Color[childRenderers.Length];
        for (int i = 0; i < childRenderers.Length; i++)
        {
            initialColors[i] = childRenderers[i].material.color;
        }
    }

    // Method to trigger fade out and destruction
    public void FadeOutAndDestroy()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private System.Collections.IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;
            for (int i = 0; i < childRenderers.Length; i++)
            {
                Color newColor = Color.Lerp(initialColors[i], Color.clear, t);
                childRenderers[i].material.color = newColor;
            }
            yield return null; // Wait for the next frame
        }

        DestroyObject();
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
        onDestroyEvent.Invoke(); // Trigger UnityEvent
    }
}
