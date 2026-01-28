using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariableNode_Holder : MonoBehaviour
{
    public VariableNode node;

    [SerializeField] private List<GameObject> pointers = new();
    [SerializeField] private TMP_Text nameField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new VariableNode();
        node.holder = this;
        node.nameField = nameField;
    }
    public void RunNode(GameObject go)
    {
        node.InstantiateVariable(go);
    }

    public void SetVal(object val)
    {
        node.SetValue(val);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
