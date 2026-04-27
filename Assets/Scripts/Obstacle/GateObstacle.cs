using UnityEngine;

public class GateObstacle : MonoBehaviour, IResettable
{
    Animator _animator;
    BoxCollider _collider;

    [SerializeField] AudioSource a;
    [SerializeField] bool _isClosed = true;

    void Start()
    {
        a = GetComponent<AudioSource>();
        _collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();

        _isClosed = !_isClosed; 
        ApplyState();
    }

    void Update()
    {
        _animator.SetBool("isClosed", _isClosed);

        if (Input.GetKeyDown(KeyCode.L))
        {
            OpenOrCloseGateNoDelay();
        }
    }

    public void OpenOrCloseGate()
    {
        Invoke(nameof(OpenOrCloseGateNoDelay), 1.5f);
    }

    void OpenOrCloseGateNoDelay()
    {
        _isClosed = !_isClosed;
        ApplyState();

        if (_isClosed)
            PlayGateCloseSound();
        else
            PlayGateOpenSound();
    }

    void ApplyState()
    {
        _collider.enabled = _isClosed;
        _animator.SetBool("isClosed", _isClosed);
    }

    public void PlayGateCloseSound()
    {
        a.PlayOneShot(SoundManager.instance.GetGateCloseSound(), 1f);
    }

    public void PlayGateOpenSound()
    {
        a.PlayOneShot(SoundManager.instance.GetGateOpenSound(), 1f);
    }

    public void ResetState()
    {
        CancelInvoke(); 

        ApplyState(); 
    }
}