using System.Collections;
using UnityEngine;

public class DasherEnemy : MonoBehaviour, IResettable
{
    [SerializeField] LayerMask _scanningLaserMask;
    [SerializeField] Transform _beamFirePoint;
    [SerializeField] GameObject _thrusterMesh;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _minIdleInterval = 3f;
    [SerializeField] float _maxIdleInterval = 8f;

    LineRenderer _lineRenderer;
    Rigidbody _rb;

    float _maxRaycastDistance = 19;
    float _currentSpeed = 0;
    float _startSpeed = 3f;
    float _maxSpeed = 15;
    float _accelerationRate = 2f;

    bool _isRushingForward = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lineRenderer = GetComponent<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlayIdleSounds());
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxRaycastDistance, _scanningLaserMask))
        {
            if (hit.collider.CompareTag("Player") && !_isRushingForward)
            {
                _isRushingForward = true;
                _lineRenderer.enabled = false;
                _thrusterMesh.SetActive(true);

                StartCoroutine(RushTowardsPlayer());
            }
        }

        ShootScanningBeam();
    }

    void ShootScanningBeam()
    {
        if (_isRushingForward) return;

        if (Physics.Raycast(_beamFirePoint.position, _beamFirePoint.forward, out RaycastHit hit, _maxRaycastDistance, _scanningLaserMask))
        {
            _lineRenderer.SetPosition(0, _beamFirePoint.position);
            _lineRenderer.SetPosition(1, hit.point);
        }
    }

    IEnumerator RushTowardsPlayer()
    {
        float elapsedTime = 0;

        while (_isRushingForward)
        {
            elapsedTime += Time.fixedDeltaTime;

            _currentSpeed = _maxSpeed * (1f - Mathf.Exp(-_accelerationRate * elapsedTime)) + _startSpeed;
            _rb.MovePosition(transform.position + transform.forward * _currentSpeed * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator PlayIdleSounds()
    {
        while (true)
        {
            SoundManager.instance.PlayClipOnSource(_audioSource,
                SoundManager.instance.GetGegnerIdleSound(), 1f, false);

            yield return new WaitForSeconds(Random.Range(_minIdleInterval, _maxIdleInterval));
        }
    }

    public void ResetState()
    {
        StopAllCoroutines();

        _isRushingForward = false;
        _currentSpeed = 0;
        _lineRenderer.enabled = true;
        _thrusterMesh.SetActive(false);

        StartCoroutine(PlayIdleSounds());
    }
}