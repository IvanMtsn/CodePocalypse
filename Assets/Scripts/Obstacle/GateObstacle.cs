using UnityEngine;

public class GateObstacle : MonoBehaviour
{
    Animator _animator;
    BoxCollider _collider;
    [SerializeField] bool _isClosed = true;
    void Start()
    {
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
            SoundManager.instance.PlayGateCloseSound();
        Debug.Log($"Is gate closed? {_isClosed}, collider {_collider.enabled}");
    }
}
