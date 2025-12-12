using System.Collections;
using UnityEngine;

public class DasherEnemy : MonoBehaviour
{
    [SerializeField] LayerMask _scanningLaserMask;
    Rigidbody _rb;
    float _maxRaycastDistance = 19;
    float _currentSpeed = 0;
    float _maxSpeed = 15;
    float _accelerationRate = 0.8f;
    bool _isRushingForward = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
                StartCoroutine(RushTowardsPlayer());
            }
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
