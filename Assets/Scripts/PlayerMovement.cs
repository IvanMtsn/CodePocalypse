using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject destination;
    public int MoveSpeed;
    public int RotateSpeed;

    Rigidbody rb;
    float timer;

    bool isMoving;
    bool isRotating;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Bewegung
        if (Vector3.Distance(transform.position, destination.transform.position) > 0.01f)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, destination.transform.position, 0.1f));
            timer += Time.fixedDeltaTime * MoveSpeed;
        }
        else if (isMoving)
        {
            ToggleMovement();
            transform.position = destination.transform.position;
            destination.transform.SetParent(transform);
            timer = 0;
        }

        //Rotation
        if ((Quaternion.Inverse(Quaternion.Euler(0, transform.eulerAngles.y, 0)) * Quaternion.Euler(0, destination.transform.eulerAngles.y, 0)).eulerAngles.y > 0.05f)
        {
            rb.MoveRotation(Quaternion.Slerp(Quaternion.Euler(0, transform.eulerAngles.y, 0), Quaternion.Euler(0, destination.transform.eulerAngles.y, 0), timer));
            timer += Time.fixedDeltaTime * RotateSpeed;
        }
        else if (isRotating)
        {
            ToggleRotation();
            transform.eulerAngles = destination.transform.eulerAngles;
            destination.transform.SetParent(transform);
            timer = 0;
        }
    }
    public void ToggleMovement()
    {
        isMoving = !isMoving;
    }
    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}
