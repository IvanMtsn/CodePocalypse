using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public abstract class CalculatingNodes : INode
{
    private INode side1, side2;
    public INode SideInput1
    {
        get
        {
            return side1;
        }
        set
        {
            if (value == null)
            {
                side1connected = false;
                side1 = null;
            }
            else
            {
                side1connected = true;
                side1 = value;
            }
        }
    }
    public INode SideInput2
    {
        get
        {
            return side2;
        }
        set
        {
            if (value == null)
            {
                side2connected = false;
                side2 = null;
            }
            else
            {
                side2connected = true;
                side2 = value;
            }
        }
    }
    public object Value { get; set; }
    public INode Input { get; set; }
    public INode Output { get; set; }

    public TMP_Text val1, val2;
    protected PointerNode var1, var2;
    protected bool side1connected, side2connected = false;

    public abstract void Calculate();

    //protected void Update()
    //{
    //    if (!side1connected && SideInput1 != null)
    //    {
    //        side1connected = true;
    //        val1.gameObject.SetActive(false);
    //    }
    //    if (side1connected && SideInput1 == null)
    //    {
    //        side1connected = false;
    //        val1.gameObject.SetActive(true);
    //    }
    //    if (!side2connected && SideInput2 != null)
    //    {
    //        side2connected = true;
    //        val2.gameObject.SetActive(false);
    //    }
    //    if (side2connected && SideInput2 == null)
    //    {
    //        side2connected = false;
    //        val2.gameObject.SetActive(true);
    //    }
    //}

    public abstract Task RunNode();

    public void Stop()
    {
        //Na
    }
}
