using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SoundManager instance;
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip CloseEditor;
    [SerializeField] private AudioClip OpenEditor;
    [SerializeField] private AudioClip PlayerStart;
    [SerializeField] private AudioClip PlayerStop;
    private AudioSource a;
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

    public void PlayCloseEditorSound() 
    {
        a.PlayOneShot(CloseEditor, 1f);
    }

    public void PlayOpenEditorSound()
    {
        a.PlayOneShot(OpenEditor, 1f);
    }

    public void PlayPlayerStartSound()
    {
        a.PlayOneShot(PlayerStart, 1f);
    }
    public void PlayPlayerStopSound()
    {
        a.PlayOneShot(PlayerStop, 1f);
    }





}
