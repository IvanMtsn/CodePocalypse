using UnityEngine;

public class storenodes : MonoBehaviour
{
    [SerializeField] GameObject line;
    
    void Start()
    {

    }

    public bool containsNode(GameObject node)
    {
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        Debug.Log( lineRenderer.GetPosition(lineRenderer.positionCount - 1) == node.transform.position);
        if (lineRenderer.GetPosition(0) == node.transform.position || lineRenderer.GetPosition(lineRenderer.positionCount - 1) == node.transform.position)
        {
            return true;
        }
        return false;
    }
}
