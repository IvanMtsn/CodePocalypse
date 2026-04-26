using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointerNode_Holder : MonoBehaviour
{
    public PointerNode node;
    [SerializeField] public Canvas canvas;
    [SerializeField] private GameObject _wertLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new PointerNode();
        node.wertLabel = _wertLabel;
        Debug.Log(_wertLabel.GetComponent<TMP_Text>().text + "ivane");
        node.GetValue();
        DragAndDrop dnd = GetComponent<DragAndDrop>();
        dnd.SetCanvas(canvas);
    }
    public async void RunNode()
    {
        await node.RunNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
