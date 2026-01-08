using System;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DivideNode : CalculatingNodes
{
    public NodeConnection Input { get; set; }
    public NodeConnection Output { get; set; }

    public async Task RunNode()
    {
        Calculate();
        await Task.Yield();
    }

    public void Stop()
    {
        //NA
    }

    public override void Calculate()
    {
        if (!side1connected && !float.TryParse(val1.text.AsSpan()[..^1], out _))
        {
            return;
        }
        if (!side2connected && !float.TryParse(val2.text.AsSpan()[..^1], out _))
        {
            return;
        }

        //Beide Seiten sind nicht verbunden
        if (!side1connected && !side2connected)
        {
            Value = float.Parse(val1.text.ToString().AsSpan()[..^1]) / float.Parse(val2.text.ToString().AsSpan()[..^1]);
        }
        //Side1 ist verbunden
        else if (side1connected && !side2connected)
        {
            Value = (float)var1.GetValue().Value / float.Parse(val2.text.ToString().AsSpan()[..^1]);
        }
        //Side2 ist verbunden
        else if (side2connected && !side1connected)
        {
            Value = float.Parse(val1.text.ToString().AsSpan()[..^1]) / (float)var2.GetValue().Value;
        }

        //Beide sind verbunden
        else if (side1connected && side2connected)
        {
            Value = (float)var1.GetValue().Value / (float)var2.GetValue().Value;
        }

        Debug.Log($"Value: {Value}");
    }
}
