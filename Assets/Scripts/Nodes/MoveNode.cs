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
    [SerializeField] LayerMask coordinateLayer;
    public float MoveLenght;
    public int MoveSpeed;

    Rigidbody rb;
    Vector3 prevPos;
    bool isMoving;
    float timer;
    bool isStopped;
    Transform dT;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isStopped)
        {
            if (isMoving && Vector3.Distance(Player.transform.position, dT.position) > 0.01f)
            {
                rb.MovePosition(Vector3.Lerp(prevPos, dT.position, timer));
                timer += Time.fixedDeltaTime * MoveSpeed;
            }
            else if (isMoving)
            {
                isMoving = false;
                Player.transform.position = dT.position;
                if (dT == destination.transform) 
                {
                    dT.SetParent(Player.transform);
                }
                timer = 0;
            }
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
        RaycastHit hit;
        if(Physics.Raycast(Player.transform.position + Player.transform.up * -1, Player.transform.up * -1, out hit, 2, coordinateLayer.value, QueryTriggerInteraction.UseGlobal))
        {
            dT = hit.transform;
            Debug.Log("Hit Cort.");
        }
        else
        {
            dT = destination.transform;
            dT.SetParent(null);
            dT.position += -1 * MoveLenght * Player.transform.up;

        }
        prevPos = Player.transform.position;
        isMoving = true;

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

    public void Stop()
    {
        isStopped = true;
    }
}
