using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public interface INode
{
    INode Input { get; set; }
    INode Output { get; set; }
    public abstract Task RunNode();
    public abstract void Stop();
}
