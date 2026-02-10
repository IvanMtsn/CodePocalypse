using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariableNode_Holder : MonoBehaviour
{
    [SerializeField] Canvas _canvas;

    public VariableNode node;
    public GameObject pointerPref_Holder;

    [SerializeField] private TMP_Text nameField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new VariableNode();
        node.holder = this;
        node.nameField = nameField;
        pointerPref_Holder.GetComponent<PointerNode_Holder>().canvas = _canvas;
    }
    public GameObject InstaniatePointer(GameObject go)
    {
        return node.InstantiateVariablePointer(go);
    }

    public void SetVal(int val)
    {
        Debug.Log("Wants to set val");
        node.SetValue(val);
    }
}
