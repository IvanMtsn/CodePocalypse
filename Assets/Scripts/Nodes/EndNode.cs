using System.Threading.Tasks;
using UnityEngine;

public class EndNode : INode
{
    public INode Input { get; set; }
    public INode Output { get; set; }

    public async Task RunNode()
    {
        await Task.Yield();
    }

    public void Stop()
    {
        //NA
    }
}
