using UnityEngine;

public class NodeConnection
{
    public INode InputNode;
    public INode OutputNode;

    public NodeConnection(INode input, INode output)
    {
        InputNode = input;
        OutputNode = output;
    }
}
