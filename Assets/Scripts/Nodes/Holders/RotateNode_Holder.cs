using TMPro;
using UnityEngine;

public class RotateNode_Holder : Holder
{
    [SerializeField] GameObject Player;
    [SerializeField] RotateDirection selectedDir;
    [SerializeField] GameObject destination;
    public int RotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new RotateNode(Player)
        {
            selectedDir = selectedDir,
            destination = destination,
            RotateSpeed = RotateSpeed
        };
    }
    public async void RunNode()
    {
        await node.RunNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
