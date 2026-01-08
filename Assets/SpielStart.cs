using UnityEngine;

public class SpielStart : MonoBehaviour
{
    [SerializeField] GameObject StartNode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRound()
    {
      var currentNode = StartNode.GetComponent<INode>();
      while (currentNode != null)
      {
          currentNode.RunNode();
          currentNode = currentNode.Output;
      }
    }
}
