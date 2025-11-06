using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MoveNode : MonoBehaviour, INode
{
    public NodeConnection Input { get; set; }
    public NodeConnection Output { get; set; }

    [SerializeField] GameObject Player;
    [SerializeField] GameObject destination;
    public float MoveLenght;
    public int MoveSpeed;

    Rigidbody rb;
    Vector3 prevPos;
    bool isMoving;
    float timer;


    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
        //destination = Player.transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        if (isMoving && Vector3.Distance(Player.transform.position, destination.transform.position) > 0.01f)
        {
            rb.MovePosition(Vector3.Lerp(prevPos, destination.transform.position, timer));
            timer += Time.fixedDeltaTime * MoveSpeed;
        }
        else if (isMoving)
        {
            isMoving = false;
            Player.transform.position = destination.transform.position;
            destination.transform.SetParent(Player.transform);
            timer = 0;
        }
    }

    public async void RunNode()
    {
        await MovePlayer();
        await Task.Yield();
    }

    //public void MovePlayer()
    public async Task MovePlayer()
    {
        Transform dT = destination.transform;
        prevPos = Player.transform.position;
        dT.SetParent(null);
        isMoving = true;
        dT.position += Player.transform.forward * MoveLenght;

        while(isMoving)
        {
            await Task.Yield();
        }
        Debug.Log("Finished Moving");
    }

    public void TestNode()
    {
        RunNode();
    }
}
