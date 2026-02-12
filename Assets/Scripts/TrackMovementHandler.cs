using UnityEngine;

public class TrackMovementHandler : MonoBehaviour
{
    [SerializeField] MeshRenderer _trackMeshRenderer;
    [SerializeField] float _scrollSpeed;
    
    [SerializeField] AudioSource a;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
          if (!a.isPlaying)
            {
                SoundManager.instance.PlayClipOnSource(a, SoundManager.instance.GetPlayPlayerMoveTrack(), 0.6f, true);
            }
            else
            {
                 if (a.isPlaying)           
                        a.Pause();
            }
    }
    void Update()
    {
        if (_rb.linearVelocity.sqrMagnitude > 0.1)
        {
            _trackMeshRenderer.material.mainTextureOffset = new Vector2(0,_scrollSpeed * Time.realtimeSinceStartup);
        }


    }
}
