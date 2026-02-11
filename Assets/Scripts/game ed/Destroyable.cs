using UnityEngine;
using UnityEngine.EventSystems;

public class Destroyable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject currentnode;
    [SerializeField] GameObject nodeField;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && currentnode.GetComponent<DragAndDrop>().placed)
        {
        Holder currentnodeHolder = currentnode.GetComponent<Holder>();
        INode currentNodeData = currentnodeHolder?.node;
        deleteLines();
        
        foreach (Transform child in nodeField.transform)
        {
            Holder othernode = child.gameObject.GetComponent<Holder>();
            if (othernode == null || othernode.node == null) continue;
            deleteInput(othernode.node);
            deleteOutput(othernode.node);
        }
        Destroy(currentnode);
        }
    }
    public void deleteInput(INode inputNode)
    {
            Holder currentnodeHolder = currentnode.GetComponent<Holder>();
            if (currentnodeHolder.node.Input == inputNode)
            {
                currentnodeHolder.node.Input = null;
                inputNode.Output = null;
            }
    }

    public void deleteOutput(INode outputNode)
    {
            Holder currentnodeHolder = currentnode.GetComponent<Holder>();
            if (currentnodeHolder.node.Output == outputNode)
            {
                currentnodeHolder.node.Output = null;
                outputNode.Input = null;
            }
    }

    public void deleteLines()
    {
        foreach (Transform child in nodeField.transform)
        {
           storenodes lineData = child.gameObject.GetComponent<storenodes>();
            if (lineData == null) continue;
           foreach (Transform childNode in currentnode.transform)
            {
                GameObject button = childNode.gameObject;
                if (lineData.containsNode(childNode.gameObject))
                {
                    Destroy(lineData.gameObject);
                }
            }
        }
    }
}