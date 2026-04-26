using System.Threading.Tasks;
using UnityEngine;
using Unity.UI;
using TMPro;

public class PointerNode : INode
{
    public PointerNode_Holder Holder;
    public VariableNode VariableNode;
    public GameObject wertLabel;

    public INode Input { get; set; }
    public INode Output { get; set; }

    public void ChangeValue(object val)
    {
        VariableNode.SetValue(val);
    }

    public VarValue GetValue()
    {
      Debug.Log(wertLabel.GetComponent<TMP_Text>().text + "ivane");
      wertLabel.GetComponent<TMP_Text>().text = VariableNode.GetValue().ToString();
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
        if(Input is CompareIfNode)
        {
            ChangeValue((Input as CompareIfNode).IsTrue);
        }
        await Task.Yield();
    }

    public void Stop()
    {
        //throw new System.NotImplementedException();
    }

    ~PointerNode()
    {
        VariableNode.RemoveVariable(Holder.gameObject);
    }
}
