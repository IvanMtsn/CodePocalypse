using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ContainingNode : MonoBehaviour, INode, IDropHandler
{
    protected List<INode> nodes = new List<INode>();
    RectTransform rectTransform;

    public virtual async Task GoThroughNodes()
    {
        foreach (INode node in nodes)
        {
            if (node is ExecuteableNode)
            {
                await(node as ExecuteableNode).Execute();
            }
            else if (node is ContainingNode)
            {
                await(node as ContainingNode).GoThroughNodes();
            }
            await Task.Yield();
        }
    }

    public bool HasContainingNode()
    {
        foreach (INode n in nodes) 
        {
            if(n is ContainingNode) 
            {
                return true; 
            }
        }
        return false;
    }

    public INode SearchRecursive(INode node)
    {
        foreach (INode n in nodes)
        {
            if(n == node) 
            {  
                return n; 
            }
            if(n is ContainingNode cn)
            {
                return cn.SearchRecursive(node) ?? null;
            }
        }
        return null;
    }
    //public INode SearchRecursive(INode node, List<INode> nodes)
    //{
    //    foreach (INode n in nodes)
    //    {
    //        if (n == node)
    //        {
    //            return n;
    //        }
    //    }
    //    return null;
    //}

    public List<INode> GetNodes() 
    {
        return nodes; 
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
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
                nodes.Add(nodeCopy.GetComponent<INode>());
                rectTransform = nodeCopy.GetComponent<RectTransform>();

            }
            else
            {
                Debug.Log("Not new");
                nodes.Add(node.GetComponent<INode>());
                SimpleNodeSystem.instance.nodes.Remove(node.GetComponent<INode>());
                rectTransform = node.GetComponent<RectTransform>();
            }
            rectTransform.SetParent(this.transform, false);
            rectTransform.anchorMax = new Vector2(0.5f, 0);
            rectTransform.anchorMin = new Vector2(0.5f, 0);
            rectTransform.anchoredPosition = new Vector2(10, -10 - (25 * (nodes.Count-1)));
        }
    }
}
