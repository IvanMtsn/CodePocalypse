using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointerNode_Holder : MonoBehaviour
{
    public PointerNode node;
    public Canvas canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new PointerNode();
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
