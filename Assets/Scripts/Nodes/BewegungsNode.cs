using System.Threading.Tasks;
using UnityEngine;

public class BewegungsNode : ExecuteableNode
{
    enum Direction
    {
        Forward, 
        Left,
        Right,
        Backward
    }
    [SerializeField] GameObject Player;
    [SerializeField] Direction selectedDir;
    public float MoveLenght;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDirection(int value)
    {
        switch (value)
        {
            case 0: selectedDir = Direction.Forward; break;
            case 1: selectedDir = Direction.Left; break;
            case 2: selectedDir = Direction.Right; break;
            case 3: selectedDir = Direction.Backward; break;
        }
    }

    public override async Task Execute()
    {
        Vector3 targetPosition;
        switch (selectedDir) 
        {
            case Direction.Forward:
                targetPosition = Player.transform.position + Player.transform.right * MoveLenght;
                //rb.MovePosition(Player.transform.position + Player.transform.right * MoveLenght);
                break;
            case Direction.Right:
                targetPosition = Player.transform.position + -Player.transform.forward * MoveLenght;
                //rb.MovePosition(Player.transform.position + Player.transform.forward * MoveLenght);
                break;
            case Direction.Left:
                targetPosition = Player.transform.position + Player.transform.forward * MoveLenght;
                //rb.MovePosition(Player.transform.position + -Player.transform.forward * MoveLenght);
                break;
            case Direction.Backward:
                targetPosition = Player.transform.position + -Player.transform.right * MoveLenght;
                //rb.MovePosition(Player.transform.position + -Player.transform.right * MoveLenght);
                break;
            default:
                targetPosition = Player.transform.position + Player.transform.right * MoveLenght;
                break;
        }
        while (Player.transform.position != targetPosition)
        {
            rb.MovePosition(targetPosition);
            await Task.Yield();
        }
        await Task.Delay(500);
    }
}
