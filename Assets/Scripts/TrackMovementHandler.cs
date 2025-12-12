using UnityEngine;

public class TrackMovementHandler : MonoBehaviour
{
    [SerializeField] MeshRenderer _trackMeshRenderer;
    [SerializeField] float _scrollSpeed;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (_rb.linearVelocity.sqrMagnitude > 0.1)
        {
            _trackMeshRenderer.material.mainTextureOffset = new Vector2(0,_scrollSpeed * Time.realtimeSinceStartup);
        }
    }
}
