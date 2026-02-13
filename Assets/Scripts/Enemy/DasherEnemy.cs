using System.Collections;
using UnityEngine;

public class DasherEnemy : MonoBehaviour
{
    [SerializeField] LayerMask _scanningLaserMask;
    [SerializeField] Transform _beamFirePoint;
    [SerializeField] GameObject _thrusterMesh;

     AudioSource _audioSource;
    LineRenderer _lineRenderer;
    Rigidbody _rb;
    float _maxRaycastDistance = 19;
    float _currentSpeed = 0;
    float _maxSpeed = 15;
    float _accelerationRate = 0.8f;
    bool _isRushingForward = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lineRenderer = GetComponent<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();
        SoundManager.instance.PlayClipOnSource(_audioSource, SoundManager.instance.GetGegnerIdleSound(), 1f, false);
    }
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxRaycastDistance, _scanningLaserMask))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Player") && !_isRushingForward)
            {
                //Debug.Log("LECKO MIO");
                _isRushingForward = true;
                _lineRenderer.enabled = false;
                _thrusterMesh.SetActive(true);
                   SoundManager.instance.PlayClipOnSource(_audioSource, SoundManager.instance.GetGegnerMoveSound(), 1f, false);
                StartCoroutine(RushTowardsPlayer());
            }
        }
        ShootScanningBeam();
    }
    void ShootScanningBeam()
    {
        if (_isRushingForward) { return; }
        else if (Physics.Raycast(_beamFirePoint.position, _beamFirePoint.forward, out RaycastHit hit, _maxRaycastDistance, _scanningLaserMask))
        {
            _lineRenderer.SetPosition(0, _beamFirePoint.position);
            _lineRenderer.SetPosition(1, hit.point);
        }
    }
    IEnumerator RushTowardsPlayer()
    {
        float elapsedTime = 0;
        while (true)
        {
            elapsedTime += Time.fixedDeltaTime;
            _currentSpeed = _maxSpeed * (1f - Mathf.Exp(-_accelerationRate * elapsedTime));
            _rb.MovePosition(transform.position + transform.forward * _currentSpeed * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
   
}
