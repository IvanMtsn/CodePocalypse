using UnityEngine;
using UnityEngine.EventSystems;

public class NodeField : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData != null)
        {
            Debug.Log("Not Null");
            DragAndDrop node = eventData.pointerDrag.GetComponent<DragAndDrop>();
            if (!node.placed)
            {
                node.placed = true;
                node.GetComponent<CanvasGroup>().blocksRaycasts = true;
                GameObject nodeCopy = eventData.pointerDrag;
                nodeCopy = Instantiate(nodeCopy, this.transform, true);
                nodeCopy.transform.SetParent(this.transform);
                node.ResetPosition();
                node.placed = false;
                SimpleNodeSystem.instance.nodes.Add(nodeCopy.GetComponent<INode>());
            }
            else
            {
                eventData.pointerDrag.transform.SetParent(this.transform);
                foreach (INode n in SimpleNodeSystem.instance.nodes)
                {
                    if (n is ContainingNode containingNode)
                    {
                        //Debug.Log(containingNode.SearchRecursive(eventData.pointerDrag.GetComponent<INode>()));
                    }
                }
            }
        }
    }
}
