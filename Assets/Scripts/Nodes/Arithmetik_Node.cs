using System;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum sign
{
    Add,
    Subtract,
    Divide,
    Multi
}

public class Arithmetik_Node : CalculatingNodes
{
    public INode Input { get; set; }
    public INode Output { get; set; }
    private INode side1, side2;
    private bool side1connected, side2connected = false;
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

    public sign selectedsign;


    public override void Calculate()
    {
      if(selectedsign == sign.Add)
      {
        CalculateAddU();
      }
      else if(selectedsign == sign.Subtract)
      {
        CalculateSubtract();
      }
      else if(selectedsign == sign.Divide)
      {
        CalculateDivid();
      }
      else if(selectedsign == sign.Multi)
      {
        CalculateMulti();
      } 
    }

    public override async Task RunNode()
    {
      Calculate();
      await Task.Yield();
    }

    public void TestNode()
    {
        RunNode();
    }

    public void Stop()
    {
        //NA
    }

    public  void CalculateAddU()
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

    public void CalculateSubtract()
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
            Value = val1f - val2f;
        }
        //Side1 ist verbunden
        else if (side1connected && !side2connected)
        {
            Value = (float)var1.GetValue().Value - val2f;
        }
        //Side2 ist verbunden
        else if (side2connected && !side1connected)
        {
            Value = val1f - (float)var2.GetValue().Value;
        }

        //Beide sind verbunden
        else if (side1connected && side2connected)
        {
            Value = (float)var1.GetValue().Value - (float)var2.GetValue().Value;
        }

        Debug.Log($"Value: {Value}");
    }

    public void CalculateMulti()
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
            Value = val1f * val2f;
        }
        //Side1 ist verbunden
        else if (side1connected && !side2connected)
        {
            Value = (float)var1.GetValue().Value * val2f;
        }
        //Side2 ist verbunden
        else if (side2connected && !side1connected)
        {
            Value = val1f * (float)var2.GetValue().Value;
        }

        //Beide sind verbunden
        else if (side1connected && side2connected)
        {
            Value = (float)var1.GetValue().Value * (float)var2.GetValue().Value;
        }

        Debug.Log($"Value: {Value}");
    }

    public void CalculateDivid()
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
            Value = val1f / val2f;
        }
        //Side1 ist verbunden
        else if (side1connected && !side2connected)
        {
            Value = (float)var1.GetValue().Value / val2f;
        }
        //Side2 ist verbunden
        else if (side2connected && !side1connected)
        {
            Value = val1f / (float)var2.GetValue().Value;
        }

        //Beide sind verbunden
        else if (side1connected && side2connected)
        {
            Value = (float)var1.GetValue().Value / (float)var2.GetValue().Value;
        }

        Debug.Log($"Value: {Value}");
    }
   }
