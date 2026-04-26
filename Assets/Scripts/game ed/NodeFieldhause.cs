using UnityEngine;
using UnityEngine.EventSystems;

public class NodeFieldhauser : MonoBehaviour, IDropHandler
{
    public LineManager lineManager;

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
                    nodeCopy = var_holder.InstaniatePointer(var_holder.pointerPref_Holder, eventData.delta, var_holder.transform);
                    Debug.Log(nodeCopy.GetComponent<PointerNode_Holder>().node.VariableNode + " black");
                }
                else
                {
                   Debug.Log("Is Not Var");
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

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     if (eventData.button != PointerEventData.InputButton.Left) return;
    //     if (lineManager == null) return;

    //     lineManager.CreateIntermediatePointAt(eventData);
    // }
}
