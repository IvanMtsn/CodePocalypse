using TMPro;
using UnityEngine;

public class NodeHolder_CollectNode : Holder
{
    [SerializeField] GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new CollectNode();
        ((CollectNode)node).Player = Player;
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
