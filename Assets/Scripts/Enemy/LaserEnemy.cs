using System.Collections;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    [SerializeField] LayerMask _laserMask;
    [SerializeField] Transform _beamFirePoint;
    AudioSource _audioSource;
    [SerializeField] float _minIdleInterval = 3f;
    [SerializeField] float _maxIdleInterval = 8f;

    LineRenderer _lineRenderer;
    float _maxRaycastDistance = 19;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayIdleSounds());
    }

    void Update()
    {
        if (Physics.Raycast(_beamFirePoint.position, _beamFirePoint.forward, out RaycastHit hit, _maxRaycastDistance, _laserMask))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyDeathHandler>().DestroyRobot();
            }
            _lineRenderer.SetPosition(0, _beamFirePoint.position);
            _lineRenderer.SetPosition(1, hit.point);
        }
    }
    IEnumerator PlayIdleSounds()
    {
        while (true)
        {
            SoundManager.instance.PlayClipOnSource(_audioSource, SoundManager.instance.GetGegnerIdleSound(), 1f, false);
            yield return new WaitForSeconds(Random.Range(_minIdleInterval, _maxIdleInterval));
        }
    }
}
