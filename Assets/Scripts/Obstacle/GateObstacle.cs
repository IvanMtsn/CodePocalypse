using System;
using System.Diagnostics;
using UnityEngine;

public class GateObstacle : MonoBehaviour
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
        _collider.enabled = _isClosed;
    }
    void Update()
    {
        _animator.SetBool("isClosed", _isClosed);
        if (Input.GetKeyDown(KeyCode.L)) { OpenOrCloseGate(); }
    }
    public void OpenOrCloseGate()
    {
        _isClosed = !_isClosed;
        _collider.enabled = _isClosed;
        if (_isClosed)
            PlayGateCloseSound();
        else
            PlayGateOpenSound();
    }

       public void PlayGateCloseSound()
    {
        a.PlayOneShot(SoundManager.instance.GetGateCloseSound(), 1f);
    }

    public void PlayGateOpenSound()
    {
        a.PlayOneShot(SoundManager.instance.GetGateOpenSound(), 1f);
    }
    
}
