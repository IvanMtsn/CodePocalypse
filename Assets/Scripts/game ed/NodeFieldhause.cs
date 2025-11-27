using UnityEngine;
using UnityEngine.EventSystems;

public class NodeFieldhauser : MonoBehaviour, IDropHandler
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
            }
            else
            {
                eventData.pointerDrag.transform.SetParent(this.transform);
            }
        }
    }
}
