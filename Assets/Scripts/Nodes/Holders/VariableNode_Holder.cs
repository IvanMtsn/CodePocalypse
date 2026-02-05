using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariableNode_Holder : MonoBehaviour
{
    public VariableNode node;

    [SerializeField] private TMP_Text nameField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new VariableNode();
        node.holder = this;
        node.nameField = nameField;
    }
    public void InstaniatePointer(GameObject go)
    {
        node.InstantiateVariablePointer(go);
    }

    public void SetVal(int val)
    {
        Debug.Log("Wants to set val");
        node.SetValue(val);
    }
}
