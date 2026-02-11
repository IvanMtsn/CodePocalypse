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
                if (nodeCopy.TryGetComponent<VariableNode_Holder>(out _))
                {
                    Debug.Log("Is Var");
                    VariableNode_Holder var_holder = nodeCopy.GetComponent<VariableNode_Holder>();
                    nodeCopy = Instantiate(var_holder.InstaniatePointer(var_holder.pointerPref_Holder), nodeCopy.transform.position, transform.rotation, transform);
                }
                else
                {
                    nodeCopy = Instantiate(nodeCopy, this.transform, true);
                }
                nodeCopy.transform.SetParent(this.transform);
                node.ResetPosition();
                node.placed = false;
            }
            else
            {
                Debug.Log("Not Placed");
                eventData.pointerDrag.transform.SetParent(this.transform);
            }
        }
    }
}
