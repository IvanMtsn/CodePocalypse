using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class CollectNode : INode
{
    public INode Input { get; set; }
    public INode Output { get; set; }

    public GameObject Player;
    LayerMask layerMask;
    GameObject objective;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CollectNode()
    {
        layerMask = LayerMask.GetMask("Objective");
    }

    public async Task RunNode()
    {
        await CollectObjective();
        await Task.Yield();
    }

    public async Task CollectObjective()
    {
        ObjectiveManager.Instance.PickUpObjective();
        await Task.Yield();
    }

    public void TestNode()
    {
        RunNode();
    }

    public void Stop()
    {
        //NA
    }
}
