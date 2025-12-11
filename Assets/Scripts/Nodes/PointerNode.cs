using UnityEngine;

public class PointerNode : MonoBehaviour, INode
{

    public VariableNode VariableNode;

    public NodeConnection Input { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public NodeConnection Output { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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
        if(Input.InputNode is ICalculatingNodes)
        {
            ChangeValue((Input.InputNode as ICalculatingNodes).Value);
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
