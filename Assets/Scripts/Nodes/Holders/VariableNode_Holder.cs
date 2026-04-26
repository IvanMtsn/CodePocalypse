using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VariableNode_Holder : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] LineManager lineManager;

    public VariableNode node;
    public GameObject pointerPref_Holder;

    [SerializeField] private TMP_Text nameField, valueField;
    [SerializeField] private GameObject nodefield;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new VariableNode();
        node.holder = this;
        node.nameField = nameField;
        if (lineManager == null)
        {
            lineManager = FindObjectOfType<LineManager>();
        }
        pointerPref_Holder.GetComponent<PointerNode_Holder>().canvas = _canvas;
        pointerPref_Holder.GetComponent<Destroyable>().nodeField = nodefield;
        foreach (Transform child in pointerPref_Holder.transform)
        {
            destroyline destroyLineComponent = child.GetComponent<destroyline>();
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
               Debug.Log("Ivan");
               button.onClick.AddListener(() => lineManager.CreateLine(child.gameObject));
            }
            if (destroyLineComponent != null)
            {
                destroyLineComponent.nodeField = nodefield;
            }
        }
    }
    public GameObject InstaniatePointer(GameObject go, Vector3 pos, Transform transform)
    {
        return node.InstantiateVariablePointer(go, pos, transform);
    }

    public void TestSpawnPointer()
    {
        node.TestSpawnPointer(pointerPref_Holder);
    }

    public void UpdateAllPointers()
    {
        node.UpdateAllPointers();
    }

    public void SetVal()
    {
        Debug.Log("Wants to set val");
        node.SetValue(valueField.text);
    }
    public void SetName()
    {
        node.SetName(nameField.text);
    }
}
