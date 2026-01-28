using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public abstract class CalculatingNodes : INode
{
    public NodeConnection SideInput1 { get; set; }
    public NodeConnection SideInput2 { get; set; }
    public object Value { get; set; }
    public INode Input { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public INode Output { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public TMP_Text val1, val2;
    protected PointerNode var1, var2;
    protected bool side1connected, side2connected = false;

    public abstract void Calculate();

    protected void Update()
    {
        if (!side1connected && SideInput1 != null)
        {
            side1connected = true;
            val1.gameObject.SetActive(false);
        }
        if (side1connected && SideInput1 == null)
        {
            side1connected = false;
            val1.gameObject.SetActive(true);
        }
        if (!side2connected && SideInput2 != null)
        {
            side2connected = true;
            val2.gameObject.SetActive(false);
        }
        if (side2connected && SideInput2 == null)
        {
            side2connected = false;
            val2.gameObject.SetActive(true);
        }
    }

    public abstract Task RunNode();

    public void Stop()
    {
        //Na
    }
}
