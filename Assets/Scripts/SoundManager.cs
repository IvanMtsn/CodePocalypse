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
    [SerializeField] AudioClip SelectEffekt;
    [SerializeField] AudioClip NodePlaceEffekt;
    [SerializeField] AudioClip NodeResetEffekt;
    [SerializeField] AudioClip DeleteNode;

    [SerializeField] private AudioSource a;
    [Header("GameSfx")]
    [SerializeField] private AudioSource b;
  
    [SerializeField] private AudioClip Player_Move;
    [SerializeField] private AudioClip Player_Zerstört;
    [SerializeField] private AudioClip PickupSound;

    [SerializeField] private AudioClip LevelCompleteJingle;

    [SerializeField] private AudioClip LevelFailedJingle;

    [SerializeField] private AudioClip FinishSound;
    [SerializeField] private AudioClip GateOpenSound;
    [SerializeField] private AudioClip GateCloseSound;
    [SerializeField] private AudioClip GegnerIdleSound;
    [SerializeField] private AudioClip GegnerMoveSound;

    [SerializeField] private AudioClip GegnerDeathSound;

    [SerializeField] private AudioClip ExplosionSound1;

    [SerializeField] private AudioClip ExplosionSound2;






    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    public void PlaySoundCLip(AudioClip audioclip, float volume)
    {
        a.PlayOneShot(audioclip, volume);
    }

    public void PlayClipOnSource(AudioSource source, AudioClip clip, float volume = 1f, bool loop = false)
 {
     if (source == null || clip == null) return;

     source.clip = clip;
     source.volume = volume;
     source.loop = loop;
     source.spatialBlend = 1f; 
     source.Play();
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

    public void PlaySelectEffekt()
    {
        a.PlayOneShot(SelectEffekt, 1f);
    }

    public void PlayNodePlaceEffekt()
    {
        a.PlayOneShot(NodePlaceEffekt, 1f);
    }

    public void PlayNodeResetEffekt()
    {
        a.PlayOneShot(NodeResetEffekt, 1f);
    }

    public void PlayNodeDeleteEffekt()
    {
        a.PlayOneShot(DeleteNode, 1f);
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
        b.PlayOneShot(PickupSound, 1f);
    }
    public AudioClip GetGateOpenSound()
    {
        return GateOpenSound;
    }
    public AudioClip GetGateCloseSound()
    {
       return  GateCloseSound;
    }

    public AudioClip GetGegnerIdleSound()
    {
        return GegnerIdleSound;
    }
    public AudioClip GetGegnerMoveSound()
    {
        return GegnerMoveSound;
    }
    public AudioClip GetGegnerDeathSound()
    {
        return GegnerDeathSound;
    }


    public AudioClip GetExplosionSound(int index)
    {
        if (index == 0)
            return ExplosionSound1;
        else
            return ExplosionSound2;
    }

    public AudioClip GetPlayPlayerMoveTrack()
    {
        return Player_Move;
    }



}
