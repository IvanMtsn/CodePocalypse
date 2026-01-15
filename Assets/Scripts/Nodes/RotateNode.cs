using System.Threading.Tasks;
using UnityEngine;

public enum RotateDirection
{
    Left,
    Right
}

public class RotateNode : MonoBehaviour, INode
{
    public INode Input { get; set; }
    public INode Output { get; set; }

    [SerializeField] GameObject Player;
    [SerializeField] RotateDirection selectedDir;
    [SerializeField] GameObject destination;
    Rigidbody rb;
    public int RotateSpeed;

    float timer;
    bool isRotating;
    bool isStopped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
        if(destination != null) destination.transform.rotation = Player.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (!isStopped)
        {
            if ((isRotating && (Quaternion.Inverse(Quaternion.Euler(0, Player.transform.eulerAngles.y, 0)) * Quaternion.Euler(0, destination.transform.eulerAngles.y, 0)).eulerAngles.y > 0.05f))
            {
                rb.MoveRotation(Quaternion.Slerp(Quaternion.Euler(Player.transform.eulerAngles.x, Player.transform.eulerAngles.y, Player.transform.eulerAngles.z), Quaternion.Euler(Player.transform.eulerAngles.x, destination.transform.eulerAngles.y, Player.transform.eulerAngles.z), timer));
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
    }

    public async Task RunNode()
    {
        await RotatePlayer();
        await Task.Yield();
    }

    public async Task RotatePlayer()
    {
        Vector3 targetDirection = rb.rotation.eulerAngles;
        Debug.Log(selectedDir.ToString());
        if (selectedDir == RotateDirection.Left)
        {
            Debug.Log("Execute Left");
            targetDirection += Vector3.back * 90;
        }
        if (selectedDir == RotateDirection.Right)
        {
            Debug.Log("Execute Right");
            targetDirection += Vector3.forward * 90;
        }


        destination.transform.SetParent(null);
        destination.transform.eulerAngles = targetDirection;
        isRotating = true;

        while (isRotating) 
        {
            await Task.Yield ();
        }
        Debug.Log("Finished Rotating");
    }
    public void TestNode()
    {
        RunNode();
    }
    
    public void OnDirectionDropdownChanged(int value)
    {
        selectedDir = (RotateDirection)value;
    }

    public void Stop()
    {
        isStopped = true;
    }
}
