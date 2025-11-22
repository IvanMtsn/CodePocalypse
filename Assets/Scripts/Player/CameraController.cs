using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _viewTarget;
    [SerializeField] float _distance;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _zoomSpeed;
    [SerializeField] bool _isBigLevel;

    float _minDistance = 14;
    float _maxDistance = 25;
    float _currentAngleHorizontal;
    float _currentAngleVertical;
    void Start()
    {
        if (_isBigLevel)
        {
            _minDistance = 14;
            _maxDistance = 25;
        }
        else
        {
            //Testwerte
            _minDistance = 10;
            _maxDistance = 20;
        }
    }
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            float deltaX = Mouse.current.delta.x.ReadValue();
            float deltaY = Mouse.current.delta.y.ReadValue();

            _currentAngleHorizontal += deltaX * _rotationSpeed;
            _currentAngleVertical -= deltaY * _rotationSpeed;

            _currentAngleVertical = Mathf.Clamp(_currentAngleVertical, -5, 65);
        }
        float scroll = Mouse.current.scroll.y.ReadValue();
        _distance -= scroll * _zoomSpeed;
        _distance = Mathf.Clamp(_distance, _minDistance, _maxDistance);


        Quaternion rotation = Quaternion.Euler(_currentAngleVertical, _currentAngleHorizontal, 0f);
        transform.position = _viewTarget.position + rotation * (Vector3.back * _distance);

        transform.LookAt(_viewTarget.position);
    }
}
