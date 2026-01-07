using UnityEngine;

public class NodeManager : MonoBehaviour
{

    [SerializeField] GameObject startNode;
    [SerializeField] GameObject endNode;
    [SerializeField] GameObject Nodefield;
    System.Collections.Generic.List<GameObject> allLines;
    System.Collections.Generic.List<GameObject> allnodes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allLines = new System.Collections.Generic.List<GameObject>();
        allnodes = new System.Collections.Generic.List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
      GetAllLinesandNodesRecursively();
      StartProgram();
    }
    void GetAllLinesandNodesRecursively()
    {
        allLines.Clear();
        allnodes.Clear();
        if (Nodefield != null)
        {
            foreach (Transform child in Nodefield.transform)
            {
                if (child.gameObject.GetComponent<Linerendererv2>() != null)
                {
                    allLines.Add(child.gameObject);
                }
            }
        }

        // Finde alle Node-Objekte per Tag "Node"
        var nodes = GameObject.FindGameObjectsWithTag("Node");
        if (nodes != null && nodes.Length > 0)
        {
            allnodes.AddRange(nodes);
        }
    }
    void StartProgram()
    {
       if (startNode == null)
        {
            Debug.Log("StartNode ist nicht gesetzt.");
            return;
        }

        // int connectedCount = 0;
        var currentNode = startNode.GetComponent<INode>();
        foreach (GameObject lineObj in allLines)
        {
            var lr = lineObj.GetComponent<Linerendererv2>();
            if (lr == null) continue;
            var pts = lr.Points;
            if (pts == null || pts.Length == 0) continue;
            if (pts[0] == startNode.transform || pts[pts.Length - 1] == startNode.transform)
            {
                // connectedCount++;
            }
        }

        // Debug-Ausgabe
        // Debug.Log($"Gefundene Linien, die mit StartNode verbunden sind: {connectedCount}");
        Debug.Log($"Gefundene Node-Objekte (Tag 'Node'): {allnodes.Count}");
    }
}
