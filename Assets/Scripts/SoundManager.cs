using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SoundManager instance;
 
    [Header("UI Sounds")]
    [SerializeField] private AudioClip CloseEditor;
    [SerializeField] private AudioClip OpenEditor;
    [SerializeField] private AudioClip PlayerStart;
    [SerializeField] private AudioClip PlayerStop;
    [SerializeField] private AudioClip MenuButton;  
    [SerializeField] private AudioSource a;
    [Header("GameSfx")]
    [SerializeField] private AudioSource b;
  
    [SerializeField] private AudioClip Player_Move;
    [SerializeField] private AudioClip PickupSound;
    [SerializeField] private AudioClip FinishSound;
    [SerializeField] private AudioClip GateOpenSound;
    [SerializeField] private AudioClip GateCloseSound;




    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    public void PlaySoundCLip(AudioClip audioclip, float volume)
    {
        a.PlayOneShot(audioclip, volume);
    }

    public void PlayTrack(AudioClip audioclip, float volume)
    {

        if (b.clip == audioclip && b.isPlaying == false)
        {
            b.UnPause();
            return;
        }
        b.clip = audioclip;
        b.volume = volume;
        b.Play();
    }
    public void StopTrack()
    {
        b.Pause();
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
    public void PlayMenuButtonSound()
    {
        a.PlayOneShot(MenuButton, 1f);
    }
    public void PlayPickupSound()
    {
        MusikManager.instance.StopMusik();
        a.PlayOneShot(PickupSound, 1f);
    }
    public void PlayGateOpenSound()
    {
        a.PlayOneShot(GateOpenSound, 1f);
    }
    public void PlayGateCloseSound()
    {
        a.PlayOneShot(GateCloseSound, 1f);
    }


    public void PlayPlayerMoveTrack()
    {
        PlayTrack(Player_Move, 1f);
    }



}
