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
    }
    void Update()
    {
        _animator.SetBool("isClosed", _isClosed);
        //if (Input.GetMouseButtonDown(0)) { OpenOrCloseGate(); }
    }
    public void OpenOrCloseGate()
    {
        _isClosed = !_isClosed;
        _collider.enabled = _isClosed;
        Debug.Log($"Is gate closed? {_isClosed}, collider {_collider.enabled}");
    }
}
