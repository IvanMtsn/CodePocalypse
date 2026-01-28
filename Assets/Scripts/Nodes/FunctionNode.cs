using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FunctionNode : INode
{
    public INode Input { get; set; }
    public INode Output { get; set; }

    public GameObject nodeField;
    
    List<INode> nodesOnField = new();
    List<INode> nodeList = new();
    //List<INode> copiedNodeList = new List<INode>();
    StartNode_Holder startNode;


    public async Task RunNode()
    {
        ReadAllNodes();
        nodeField.SetActive(false);
        INode currentNode;
        if (startNode)
        {
            currentNode = startNode.node;
        }
        else currentNode = nodeList[0];
        Debug.Log(currentNode.GetType());
        while (currentNode != null) 
        {
            await currentNode.RunNode();
            currentNode = currentNode.Output;
        }
        await Task.Yield();
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }

    public void ReadAllNodes()
    {
        INode currentNode;
        nodesOnField.Clear();
        nodeList.Clear();
        foreach (Holder n in nodeField.transform.GetComponentsInChildren<Holder>())
        {
            if(n is StartNode_Holder node)
            {
                startNode = node;
            }
            nodesOnField.Add(n.node);
        }

        currentNode = startNode.node;
        for (int i = 0; i < nodesOnField.Count; i++) 
        {
            nodeList.Add(currentNode);
            currentNode = currentNode.Output;
        }

        Debug.Log(nodeList.Count);
        Debug.Log(nodeList[0]);
    }

    public void TestNode()
    {
        RunNode();
    }

    public void CopyNodes()
    {

    }
}
