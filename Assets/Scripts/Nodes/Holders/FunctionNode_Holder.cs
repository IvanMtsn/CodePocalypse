using UnityEngine;

public class NodeHolder_FunctionNode : MonoBehaviour
{
    public FunctionNode node;

    [SerializeField] GameObject nodeField;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        node = new FunctionNode();
        node.nodeField = nodeField;
    }

    public void RunNode()
    {
        node.RunNode();
    }
}
