using System;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum CompareOptions
{
    Smaller,
    SmallerOrEqual,
    Equal,
    GreaterOrEqual,
    Greater,
    Not
}

public class CompareIfNode : INode
{
    public INode Input { get; set; }

    //Im Set sollen ein side1/2connected gesetzt werden
    //Ersätz abfrage in Update
    public INode SideInput1 { get; set; }
    public INode SideInput2 { get; set; }
    public INode Output { get; set; }
    public INode Output2 { get; set; }
    public bool IsTrue { get; set; }

    public TMP_Dropdown comparer;
    public TMP_Text val1, val2;
    public CompareOptions selectedComparer;
    private PointerNode var1, var2;

    private bool side1connected, side2connected = false;

    private void Update()
    {
        if (!side1connected && SideInput1 != null)
        {
            side1connected = true;
            val1.gameObject.SetActive(false);
        }
        if(side1connected && SideInput1 == null)
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

    public CompareIfNode()
    {
        UpdateCaller.AddUpdateCallback(Update);
    }

    public async Task RunNode()
    {
        Check();
        await Task.Yield();
    }

    public void Check()
    {
        //Keine Var, Val1 wird gepr�ft
        //.AsSpan()[..^1] weil InputField komisch ist
        if (!side1connected && !float.TryParse(val1.text.AsSpan()[..^1], out _) && !(selectedComparer == CompareOptions.Equal || selectedComparer == CompareOptions.Not))
        {
            return;
        }
        if (!side2connected && !float.TryParse(val2.text.AsSpan()[..^1], out _) && !(selectedComparer == CompareOptions.Equal || selectedComparer == CompareOptions.Not))
        {
            return;
        }

        switch (selectedComparer)
        {
            case CompareOptions.Smaller:
                if (side1connected)
                {
                    if (side2connected)
                    {
                        IsTrue = (float)var1.GetValue().Value < (float)var2.GetValue().Value;
                        return;
                    }
                    IsTrue = (float)var1.GetValue().Value < float.Parse(val2.text.AsSpan()[..^1]);
                }
                else if (side2connected)
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) < (float)var2.GetValue().Value;
                }
                else
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) < float.Parse(val2.text.AsSpan()[..^1]);
                }
                break;
            case CompareOptions.SmallerOrEqual:
                if (side1connected)
                {
                    if (side2connected)
                    {
                        IsTrue = (float)var1.GetValue().Value <= (float)var2.GetValue().Value;
                        return;
                    }
                    IsTrue = (float)var1.GetValue().Value <= float.Parse(val2.text.AsSpan()[..^1]);
                }
                else if (side2connected)
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) <= (float)var2.GetValue().Value;
                }
                else
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) <= float.Parse(val2.text.AsSpan()[..^1]);
                }
                break;
            case CompareOptions.Equal:
                if (side1connected)
                {
                    if (side2connected)
                    {
                        IsTrue = var1.GetValue().Value == var2.GetValue().Value;
                        return;
                    }
                    IsTrue = var1.GetValue().Value.ToString() == val2.text;
                }
                else if (side2connected)
                {
                    IsTrue = val1.text == var2.GetValue().Value.ToString();
                }
                else
                {
                    IsTrue = val1.text == val2.text;
                }
                break;
            case CompareOptions.GreaterOrEqual:
                if (side1connected)
                {
                    if (side2connected)
                    {
                        IsTrue = (float)var1.GetValue().Value >= (float)var2.GetValue().Value;
                        return;
                    }
                    IsTrue = (float)var1.GetValue().Value >= float.Parse(val2.text.AsSpan()[..^1]);
                }
                else if (side2connected)
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) >= (float)var2.GetValue().Value;
                }
                else
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) >= float.Parse(val2.text.AsSpan()[..^1]);
                }
                break;
            case CompareOptions.Greater:
                if (side1connected)
                {
                    if (side2connected)
                    {
                        IsTrue = (float)var1.GetValue().Value > (float)var2.GetValue().Value;
                        return;
                    }
                    IsTrue = (float)var1.GetValue().Value > float.Parse(val2.text.AsSpan()[..^1]);
                }
                else if (side2connected)
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) > (float)var2.GetValue().Value;
                }
                else
                {
                    IsTrue = float.Parse(val1.text.AsSpan()[..^1]) > float.Parse(val2.text.AsSpan()[..^1]);
                }
                break;
            case CompareOptions.Not:
                if (side1connected)
                {
                    if (side2connected)
                    {
                        IsTrue = var1.GetValue().Value != var2.GetValue().Value;
                        return;
                    }
                    IsTrue = var1.GetValue().Value.ToString() != val2.text;
                }
                else if (side2connected)
                {
                    IsTrue = val1.text != var2.GetValue().Value.ToString();
                }
                else
                {
                    IsTrue = val1.text != val2.text;
                }
                break;
            default:
                selectedComparer = CompareOptions.Smaller;
                break;
        }
        Debug.Log($"IsTrue: {IsTrue}");
    }

    public void TestNode()
    {
        RunNode();
    }

    public INode GetOutput()
    {
        Check();
        if (IsTrue) return Output;
        return Output2;
    }

    public void Stop()
    {
        //NA
    }
}
