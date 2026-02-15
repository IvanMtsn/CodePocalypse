using System;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AddNode : CalculatingNodes
{
    public override async Task RunNode()
    {
        //UpdateCaller.AddUpdateCallback(Update);
        Calculate();
        await Task.Yield();
    }
    ~AddNode() 
    {
        //UpdateCaller.UnsubscribeUpdateCallback(Update);
    }

    public override void Calculate()
    {
        float val1f = 0;
        float val2f = 0;
        if (!side1connected && !float.TryParse(val1.text.AsSpan()[..^1], out val1f))
        {
            return;
        }
        if (!side2connected && !float.TryParse(val2.text.AsSpan()[..^1], out val2f))
        {
            return;
        }
        //out speichern

        //Beide Seiten sind nicht verbunden
        if (!side1connected && !side2connected)
        {
            Value = val1f + val2f;
        }
        //Side1 ist verbunden
        else if(side1connected && !side2connected)
        {
            Value = (float)var1.GetValue().Value + val2f;
        }
        //Side2 ist verbunden
        else if (side2connected && !side1connected)
        {
            Value = val1f + (float)var2.GetValue().Value;
        }

        //Beide sind verbunden
        else if (side1connected && side2connected)
        {
            Value = (float)var1.GetValue().Value + (float)var2.GetValue().Value;
        }

        Debug.Log($"Value: {Value}");
    }
}
