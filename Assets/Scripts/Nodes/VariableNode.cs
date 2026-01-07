using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class VariableNode : MonoBehaviour
{
    //[SerializeField] GameObject PointerPref;
    [SerializeField] private List<GameObject> pointers = new ();
    [SerializeField] private TMP_Text nameField;

    private VarValue varVal = new VarValue();
    public string Name;

    public void InstantiateVariable(GameObject go)
    {
        if(!go.GetComponent<PointerNode>()) return;
        Name = nameField.text;
        //GameObject var = Instantiate(PointerPref);
        go.GetComponent<PointerNode>().VariableNode = this;
        go.GetComponentInChildren<TMP_Text>().text = this.Name;
        pointers.Add(go);
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
        Debug.Log($"is:" + (newVal.GetType() == typeof(System.Int32)));
        //TODO: switch mit gültigen Typen und varVal.Type setzen
        varVal.Value = newVal;
        Debug.Log($"Var value: {varVal.Value}");
    }

    private void UpdateAllPointers()
    {
        foreach (var point in pointers)
        {
            point.GetComponent<TMP_Text>().text = Name;
            point.GetComponent<PointerNode>().GetValue();
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
            Destroy(poi);
        }
    }
    public void RemoveVariable(GameObject pointer)
    {
        pointers.Remove(pointer);
    }
}
