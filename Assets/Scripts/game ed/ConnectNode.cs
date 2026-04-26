using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class ConnectNode : INode
{
    public INode Input { get; set; }
    public INode Output { get; set; }

    public async Task RunNode()
    {
        Debug.Log("raaah");
        await Task.Yield();
    }

    public void Stop()
    {
        //NA
    }
}
