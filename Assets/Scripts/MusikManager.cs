using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusikManager : MonoBehaviour
{
    public static MusikManager instance;

    [SerializeField] private AudioSource Musik_AudioSource;
    [SerializeField] private AudioClip Menu_AudioClip;
    [SerializeField] private AudioClip Action_AudioClip;
    [SerializeField] private AudioClip Node_AudioClip;
    [SerializeField] private AudioClip Player_Startup;

    private AudioSource a;


    private Dictionary<AudioClip, float> savedPositions = new Dictionary<AudioClip, float>();

    private AudioClip currentClip;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
            
        a = GetComponent<AudioSource>();
    }

    public void PlayMusik(AudioClip audioclip, float volume)
    {

        if (a.clip == audioclip && a.isPlaying == false)
        {
            a.UnPause();
            return;
        }
        a.clip = audioclip;
        a.volume = volume;
        a.Play();
    }

    private IEnumerator PlayActionAfterClip(AudioClip audioClip)
    {
        
        PlayMusik(audioClip, 1f);

        // Warten, bis der Clip vorbei ist
        yield return new WaitForSeconds(audioClip.length);

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

    public void StopMusik() 
    {
        a.Pause();
    }
}
    
