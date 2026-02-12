using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{
    [SerializeField] RectTransform panelRectTransform;
    // public void Start()
    // {
    //     // Initial scale of the panel
    //     panelRectTransform.localScale = new Vector3(1f, 1f, 1f);
    // }
    // public void ShrinkPanel()
    // {
    //     panelRectTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    // }
    public void ResetPanel()
    {
        panelRectTransform.localScale = new Vector3(1f, 1f, 1f);
        Vector2 originalPosition = new Vector2(90f, 0f); // Ursprüngliche Position
        panelRectTransform.anchoredPosition = originalPosition; 
    }

    [Header("Ziel-Einstellungen")]
    public float targetScale = 0.3f;
    public Vector2 targetPosition = new Vector2(-50f, 100f); // Neue Position
    
    [Header("Animation")]
    public float duration = 0.5f;
    
    void Start()
    {

    }
    
    public void ScaleAndMove()
    {
        StartCoroutine(AnimateScaleAndPosition());
    }
    
    IEnumerator AnimateScaleAndPosition()
    {
        Vector3 startScale = panelRectTransform.localScale;
        Vector2 startPosition = panelRectTransform.anchoredPosition;
        
        Vector3 endScale = new Vector3(targetScale, targetScale, 1f);
        Vector2 endPosition = targetPosition;
        
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);
            
            // Gleichzeitig skalieren UND bewegen
            panelRectTransform.localScale = Vector3.Lerp(startScale, endScale, t);
            panelRectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            
            yield return null;
        }
        
        panelRectTransform.localScale = endScale;
        panelRectTransform.anchoredPosition = endPosition;
    }
}