using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.Rotate(Vector3.zero);
        _rb = GetComponent<Rigidbody>();
        _rb.MoveRotation(Quaternion.Euler(0, 0, 0));
        Debug.Log(_rb.rotation.eulerAngles.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
