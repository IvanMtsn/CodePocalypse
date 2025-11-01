using System.Threading.Tasks;
using UnityEngine;

public enum RotateDirection
{
    Left,
    Right
}

public class RotateNode : MonoBehaviour, INode
{
    public NodeConnection Input { get; set; }
    public NodeConnection Output { get; set; }

    [SerializeField] GameObject Player;
    [SerializeField] RotateDirection selectedDir;
    [SerializeField] GameObject destination;
    Rigidbody rb;
    public int RotateSpeed;

    float timer;
    bool isRotating;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if ((isRotating && (Quaternion.Inverse(Quaternion.Euler(0, Player.transform.eulerAngles.y, 0)) * Quaternion.Euler(0, destination.transform.eulerAngles.y, 0)).eulerAngles.y > 0.05f))
        {
            rb.MoveRotation(Quaternion.Slerp(Quaternion.Euler(0, Player.transform.eulerAngles.y, 0), Quaternion.Euler(0, destination.transform.eulerAngles.y, 0), timer));
            timer += Time.fixedDeltaTime * RotateSpeed;
        }
        else if (isRotating)
        {
            isRotating = false;
            Player.transform.eulerAngles = destination.transform.eulerAngles;
            destination.transform.SetParent(Player.transform);
            timer = 0;
        }
    }

    public async Task RunNode()
    {
        //awate RotatePlayer();
        await Task.Yield();
    }

    public void RotatePlayer()
    //public async Task RotatePlayer()
    {
        Vector3 targetDirection = rb.rotation.eulerAngles;
        Debug.Log(selectedDir.ToString());
        if (selectedDir == RotateDirection.Left)
        {
            Debug.Log("Execute Left");
            targetDirection += Vector3.down * 90;
        }
        if (selectedDir == RotateDirection.Right)
        {
            Debug.Log("Execute Right");
            targetDirection += Vector3.up * 90;
        }


        destination.transform.SetParent(null);
        destination.transform.eulerAngles = targetDirection;
        isRotating = true;

        //await Task.Yield ();
        Debug.Log("Finished Rotating");
    }
}
