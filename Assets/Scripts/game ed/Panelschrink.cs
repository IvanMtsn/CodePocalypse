using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{
    public RectTransform panel;
    public float duration = 0.5f;
    
    public void ShrinkPanel()
    {
        StartCoroutine(AnimateSize(panel.sizeDelta, new Vector2(200f, 150f)));
    }
    
    IEnumerator AnimateSize(Vector2 startSize, Vector2 endSize)
    {
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            
            // Smooth interpolation
            panel.sizeDelta = Vector2.Lerp(startSize, endSize, t);
            
            yield return null;
        }
        
        panel.sizeDelta = endSize;
    }
}