using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource m_AudioSource;
    private AudioSource a;
    public AudioSource musicSource;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        a = GetComponent<AudioSource>();
    }

    
    public void PlaySoundCLip(AudioClip audioclip, float volume)
    {
        a.PlayOneShot(audioclip, volume);
    }


    public void PlaySoundFXCLip(AudioClip audioclip, Transform spawnTransform, float volume) 
    {
        AudioSource audioSource = Instantiate(m_AudioSource, spawnTransform.position, Quaternion.identity); 

        audioSource.clip = audioclip;

        audioSource.volume = volume;    

        audioSource.Play();

        float cliplength = audioSource.clip.length;

        Destroy(audioSource.gameObject, cliplength );
    }
}
