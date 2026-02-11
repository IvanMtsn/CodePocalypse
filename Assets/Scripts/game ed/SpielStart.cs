using System.Threading.Tasks;
using UnityEngine;

public class SpielStart : MonoBehaviour
{
    [SerializeField] GameObject StartNode;
    public int DelayMS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void StartRound()
    {
      var currentNode = StartNode.GetComponent<Holder>().node;
      while (currentNode != null)
      {
          await currentNode.RunNode();
          await Task.Delay(DelayMS);
          currentNode = currentNode.Output;
      }
        Debug.Log("No more Nodes");
    }
}
