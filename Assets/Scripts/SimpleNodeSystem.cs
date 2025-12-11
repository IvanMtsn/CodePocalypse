using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNodeSystem : MonoBehaviour
{
    public static SimpleNodeSystem instance;
    public List<INode> nodes = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async void RunNodes()
    {
        foreach (INode node in nodes) 
        {
            if (node is ExecuteableNode)
            {
                await (node as ExecuteableNode).Execute();
            }
            if (node is ContainingNode)
            {
                await (node as ContainingNode).GoThroughNodes();
            }
        }
    }
}
