using UnityEngine;

public class StartNode : MonoBehaviour, INode
{
    public INode Input { get; set; }
    public INode Output { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input = null;
    }

    public void RunNode()
    {
        
    }

    public void Stop()
    {
        //NA
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
