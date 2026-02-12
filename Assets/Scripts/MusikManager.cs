using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusikManager : MonoBehaviour
{
    public static MusikManager instance;

    [SerializeField] private AudioSource Ambient_AudioSource;
    [SerializeField] private AudioSource Music_AudioSource;
    [SerializeField] private AudioClip Menu_AudioClip;
    [SerializeField] private AudioClip Action_AudioClip;
    [SerializeField] private AudioClip Node_AudioClip;
    [SerializeField] private AudioClip Player_Startup;
    [SerializeField] private AudioClip Ambient_Track;

   

    private AudioClip currentClip;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
            
        
    }

    public void PlayMusik(AudioClip audioclip, float volume)
    {
        StopAmbient();
        if (Music_AudioSource.clip == audioclip && Music_AudioSource.isPlaying == false)
        {
            Music_AudioSource.UnPause();
            return;
        }
        Music_AudioSource.clip = audioclip;
        Music_AudioSource.volume = volume;
        Music_AudioSource.Play();
    }


    private IEnumerator PlayActionAfterClip(AudioClip introClip)
    {
      

        yield return new WaitForSeconds(introClip.length);

        // Danach Action-Musik starten
        PlayMusik(Action_AudioClip, 1f);
    }

    public void PlayMusikAction()
    {

        StartCoroutine(PlayActionAfterClip(Player_Startup));
    }

    public void PlayMusikMenu()
    {
        PlayMusik(Menu_AudioClip, 1f);
    }
    public void PlayMusikNode()
    {
        PlayMusik(Node_AudioClip, 1f);
    }
    public void PlayAmbientTrack()
    {
        if (!Music_AudioSource.isPlaying)
        {
            Ambient_AudioSource.volume = 0.5f;
            Ambient_AudioSource.clip = Ambient_Track;
            Ambient_AudioSource.Play();
        }
        else
        {
            Ambient_AudioSource.Pause();
        }
            
    }
  

    public void StopMusik() 
    {
        Music_AudioSource.Pause();
        instance.PlayAmbientTrack();
    }
    private void StopAmbient()
{
    if (Ambient_AudioSource.isPlaying)
    {
        Ambient_AudioSource.Pause();
    }
}
}
    
