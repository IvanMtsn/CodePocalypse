using System.Threading.Tasks;
using UnityEngine;

public class PointerNode : MonoBehaviour, INode
{

    public VariableNode VariableNode;

    public INode Input { get; set; }
    public INode Output { get; set; }

    public void ChangeValue(object val)
    {
        VariableNode.SetValue(val);
    }

    public VarValue GetValue()
    {
        return VariableNode.GetValue();
    }

    public async Task RunNode()
    {
        if(Input is CalculatingNodes)
        {
            ChangeValue((Input as CalculatingNodes).Value);
        }
        if (Input is PointerNode)
        {
            ChangeValue((Input as PointerNode).VariableNode.GetValue());
        }
        await Task.Yield();
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
