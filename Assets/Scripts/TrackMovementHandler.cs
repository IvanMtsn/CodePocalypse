using UnityEngine;

public class TrackMovementHandler : MonoBehaviour
{
    [SerializeField] MeshRenderer _trackMeshRenderer;
    [SerializeField] float _scrollSpeed;

    [SerializeField] AudioSource a;

    [SerializeField] bool isPlayer = true;

    
    Rigidbody _rb;
    bool _wasMoving = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool isMoving = _rb.linearVelocity.sqrMagnitude > 0.1f;

        if (isMoving)
        {
            _trackMeshRenderer.material.mainTextureOffset = new Vector2(0, _scrollSpeed * Time.realtimeSinceStartup);
        }

        if (isMoving != _wasMoving)
        {
            if (isMoving)
                if (isPlayer)
                {
                    SoundManager.instance.PlayClipOnSource(a, SoundManager.instance.GetPlayPlayerMoveTrack(), 0.6f, true);
                }
                else
                    SoundManager.instance.PlayClipOnSource(a, SoundManager.instance.GetDasherGegnerMoveSound(), 1f, true);
            else
                a.Pause();

            _wasMoving = isMoving;
        }
    }
}
