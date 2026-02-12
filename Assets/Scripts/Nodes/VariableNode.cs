using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class VariableNode
{
    //[SerializeField] GameObject PointerPref;
    public List<GameObject> pointers = new ();
    public TMP_Text nameField;
    public VariableNode_Holder holder;

    private VarValue varVal = new VarValue();
    public string Name;

    public GameObject InstantiateVariablePointer(GameObject go)
    {
        if(!go.GetComponent<PointerNode_Holder>()) return null;
        Name = nameField.text;
        GameObject var = GameObject.Instantiate(go, holder.transform.position, holder.transform.rotation);
        Debug.Log(var.GetComponent<PointerNode_Holder>().node);
        var.GetComponent<PointerNode_Holder>().node.VariableNode = this;
        var.GetComponentInChildren<TMP_Text>().text = this.Name;
        pointers.Add(var);
        Debug.Log(pointers.Count);
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
        Debug.Log(newVal.GetType());
        Debug.Log($"is Int:" + (newVal.GetType() == typeof(System.Int32)));
        //TODO: switch mit gültigen Typen und varVal.Type setzen
        switch (newVal)
        {
            case System.Int32: varVal.varType = VarType.Int;
                break;
            case System.Boolean: varVal.varType = VarType.Bool;
                break;
        }
        varVal.Value = newVal;
        UpdateAllPointers();
        Debug.Log($"Var value: {varVal.Value}");
    }

    private void UpdateAllPointers()
    {
        foreach (var point in pointers)
        {
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
        InstantiateVariablePointer(Pointerholder);
    }
}
