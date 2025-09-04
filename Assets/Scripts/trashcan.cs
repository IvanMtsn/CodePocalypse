using UnityEngine;
using UnityEngine.EventSystems;

public class trashcan : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragAndDrop node = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (node.placed)
        {
            SimpleNodeSystem.instance.nodes.Remove(eventData.pointerDrag.GetComponent<INode>());
            Destroy(eventData.pointerDrag);
        }
    }
}
