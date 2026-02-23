using System.Threading.Tasks;
using UnityEngine;

public class EndNode : MonoBehaviour, INode
{
    public INode Input { get; set; }
    public INode Output { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    public async Task RunNode()
    {
        await Task.Yield();
    }

    public void Stop()
    {
        //NA
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
