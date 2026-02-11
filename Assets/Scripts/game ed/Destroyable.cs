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
            deleteOutput(othernode.gameObject);
            deleteInput(othernode.gameObject);
        }
        Destroy(currentnode);
        }
    }
    public void deleteInput(GameObject inputNode)
    {
            Holder currentnodeHolder = currentnode.GetComponent<Holder>();
            Holder inputNodeHolder = inputNode.GetComponent<Holder>();
            if (currentnodeHolder == null || currentnodeHolder.node == null || inputNodeHolder == null || inputNodeHolder.node == null) return;
            
            INode inputNodeData = inputNodeHolder.node;
            if (currentnodeHolder.node.Input == inputNodeData)
            {
                currentnodeHolder.node.Input = null;
                inputNodeData.Output = null;
            }
    }

    public void deleteOutput(GameObject outputNode)
    {
            Holder currentnodeHolder = currentnode.GetComponent<Holder>();
            Holder outputNodeHolder = outputNode.GetComponent<Holder>();
            if (currentnodeHolder == null || currentnodeHolder.node == null || outputNodeHolder == null || outputNodeHolder.node == null) return;
            
            INode outputNodeData = outputNodeHolder.node;
            if (currentnodeHolder.node.Output == outputNodeData)
            {
                currentnodeHolder.node.Output = null;
                outputNodeData.Input = null;
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