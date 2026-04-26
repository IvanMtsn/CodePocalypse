using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class VariableNode
{
    public List<GameObject> pointers = new ();
    public TMP_Text nameField;
    public VariableNode_Holder holder;

    private VarValue varVal = new VarValue();
    public string Name;

    public GameObject InstantiateVariablePointer(GameObject go, Vector3 pos, Transform trnsfrm)
    {
        if(!go.GetComponent<PointerNode_Holder>()) return null;
        Name = nameField.text;
        GameObject var = GameObject.Instantiate(go, holder.transform.position, holder.transform.rotation, trnsfrm);
        var.GetComponent<PointerNode_Holder>().node.VariableNode = this;
        var.GetComponentInChildren<TMP_Text>().text = this.Name;
        var.GetComponent<PointerNode_Holder>().node.GetValue();
        pointers.Add(var);
        return var;
    }

    public void TestSetFunc()
    {
        SetValue(1);
    }

    public VarValue GetValue()
    {
        return varVal;
    }

    public void SetValue(object newVal)
    {
        Debug.Log(newVal+ " " + newVal.GetType());
        try
        {
            newVal = System.Convert.ToBoolean(newVal.ToString());
            varVal.varType = VarType.Bool;
            Debug.Log("Converted to bool");
        }
        catch (Exception ex) { }

        if (int.TryParse(newVal.ToString(), out int newValInt))
        {
            Debug.Log("Converted to int");
            newVal = newValInt;
            varVal.varType = VarType.Int;
        }
        Debug.Log(newVal+ " " + newVal.GetType());
            Debug.Log($"is Int:" + (newVal.GetType() == typeof(System.Int32)));
        //Debug.Log($"is Bool:" + (System.Convert.ToBoolean(newVal).GetType() == typeof(System.Boolean)));

        switch (newVal)
        {
            case System.Int32:
                varVal.varType = VarType.Int;
                break;
            case System.Boolean:
                varVal.varType = VarType.Bool;
                break;
        }
        varVal.Value = newVal;
        UpdateAllPointers();
        Debug.Log($"Var value: {varVal.Value} {varVal.varType}");
    }

    public void UpdateAllPointers()
    {
        foreach (var point in pointers)
        {
            Debug.Log(point.name + point.GetComponentInChildren<TMP_Text>().text + Name);
            point.GetComponentInChildren<TMP_Text>().text = Name;
            point.GetComponent<PointerNode_Holder>().node.GetValue();
        }
    }

    public void ToggelType()
    {
        if (varVal.varType == VarType.Int) varVal.varType = VarType.Bool;
        else varVal.varType = VarType.Int;
    }

    public void SetType(VarType type)
    {
        varVal.varType = type;
    }

    public void SetName(string name)
    {
        Debug.Log("Set Name: " + name);
        Name = name;
        UpdateAllPointers();
    }

    public void DestroyAllVariables() 
    {
        foreach (GameObject poi in pointers)
        {
            GameObject.Destroy(poi);
        }
    }
    public void RemoveVariable(GameObject pointer)
    {
        pointers.Remove(pointer);
    }

    public void TestSpawnPointer(GameObject Pointerholder)
    {
        InstantiateVariablePointer(Pointerholder, Vector3.one, null);
    }
}
