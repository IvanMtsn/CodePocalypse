using UnityEngine;
using UnityEngine.EventSystems;

public class ConditionSlot : MonoBehaviour, IDropHandler
{
    public GameObject IfNodeGO;
    IfNode ifNode;

    private void Start()
    {
        ifNode = IfNodeGO.GetComponent<IfNode>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null && eventData.pointerDrag.GetComponent<ICondition>() != null)
        {
            DragAndDrop node = eventData.pointerDrag.GetComponent<DragAndDrop>();
            if (!node.placed)
            {
                node.placed = true;
                node.GetComponent<CanvasGroup>().blocksRaycasts = true;
                GameObject nodeCopy = eventData.pointerDrag;
                nodeCopy = Instantiate(nodeCopy, this.transform, true);
                //nodeCopy.transform.SetParent(this.transform);
                node.ResetPosition();
                node.placed = false;
                //nodes.Add(nodeCopy.GetComponent<INode>());
                ifNode.condition = nodeCopy.GetComponent<ICondition>();

                node = nodeCopy.GetComponent<DragAndDrop>();
            }
            else
            {
                Debug.Log("Not new");
                //ifNode.nodes.Add(node.GetComponent<INode>());
                ifNode.condition = node.GetComponent<ICondition>();
                SimpleNodeSystem.instance.nodes.Remove(node.GetComponent<INode>());
            }

            RectTransform rectTransform = node.GetComponent<RectTransform>();
            rectTransform.SetParent(this.transform, true);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
