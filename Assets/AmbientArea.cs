using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindScript : MonoBehaviour
{
    [SerializeField] private Collider Area;
    [SerializeField] private GameObject Player;

     [SerializeField] private AudioSource WindSound;

       
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float maxVolume = 1f;
    
    private Coroutine currentFadeCoroutine;

    void Start()
    {
        WindSound.volume = 0f;
        WindSound.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
           
            if (currentFadeCoroutine != null)
                StopCoroutine(currentFadeCoroutine);
            
            currentFadeCoroutine = StartCoroutine(FadeInWind(true, fadeDuration, maxVolume));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
           
            if (currentFadeCoroutine != null)
                StopCoroutine(currentFadeCoroutine);
            
            currentFadeCoroutine = StartCoroutine(FadeInWind(false, fadeDuration, 0f));
        }
    }

    public IEnumerator FadeInWind(bool fadeIn, float duration, float targetVolume)
     {
        
        if(!fadeIn)
        {
            double lengthOfSource = (double)WindSound.clip.samples / WindSound.clip.frequency;
            yield return new WaitForSeconds((float)lengthOfSource-duration);
        }

        float startVolume = WindSound.volume;
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            WindSound.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        yield break;
    }
    

    
}
