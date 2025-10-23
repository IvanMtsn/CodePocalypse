using System.Threading.Tasks;
using UnityEngine;

public class MoveNode : Node
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject destination;
    [SerializeField] public float MoveLenght;
    Rigidbody rb;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
        //destination = Player.transform.GetChild(0).gameObject;
    }

    public override async Task RunNode()
    {
        //await MovePlayer();
        await Task.Yield();
    }

    //public async Task MovePlayer()
    public void MovePlayer()
    {
        Transform dT = destination.transform;
        dT.SetParent(null);
        Debug.Log($"Pos before: {dT.position}");
        Player.GetComponent<PlayerMovement>().ToggleMovement();
        dT.position += Player.transform.forward;
        Debug.Log($"Pos after: {dT.position}");

        //await Task.Delay(100);
        Debug.Log("Finished");
    }
}
