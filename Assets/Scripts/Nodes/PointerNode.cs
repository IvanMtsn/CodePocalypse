using UnityEngine;

public class PointerNode : MonoBehaviour, INode
{

    public VariableNode VariableNode;

    public NodeConnection Input { get; set; }
    public NodeConnection Output { get; set; }

    public void ChangeValue(object val)
    {
        VariableNode.SetValue(val);
    }

    public VarValue GetValue()
    {
        return VariableNode.GetValue();
    }

    public void RunNode()
    {
        if(Input.InputNode is CalculatingNodes)
        {
            ChangeValue((Input.InputNode as CalculatingNodes).Value);
        }
        if (Input.InputNode is PointerNode)
        {
            ChangeValue((Input.InputNode as PointerNode).VariableNode.GetValue());
        }
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }

    private void OnDestroy()
    {
        VariableNode.RemoveVariable(gameObject);
    }
}
