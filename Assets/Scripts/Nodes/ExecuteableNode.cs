using System.Threading.Tasks;
using UnityEngine;

public abstract class ExecuteableNode : MonoBehaviour, INode
{
    public abstract Task Execute();
}
