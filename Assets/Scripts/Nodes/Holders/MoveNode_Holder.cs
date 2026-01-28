using Unity.VisualScripting;
using UnityEngine;

public class NodeHolder_Move : Holder
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject destination;
    [SerializeField] LayerMask coordinateLayer;
    public float MoveLenght;
    public int MoveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new MoveNode(Player)
        {
            //node.Player = Player;
            destination = destination,
            coordinateLayer = coordinateLayer,
            MoveLenght = MoveLenght,
            MoveSpeed = MoveSpeed
        };
    }

    public void RunNode()
    {
        node.RunNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
