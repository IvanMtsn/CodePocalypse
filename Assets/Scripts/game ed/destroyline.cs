using UnityEngine;
using UnityEngine.EventSystems;

public class destroyline : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject nodeField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      if (eventData.button == PointerEventData.InputButton.Right)
      {
          Debug.Log(this.gameObject.name);
          GameObject parentNode = this.gameObject.transform.parent.gameObject;
          storenodes lineData;
          Destroyable parentdestroyable = parentNode.GetComponent<Destroyable>();
          if (this.gameObject.name.Contains("Input"))
          {
              foreach (Transform child in nodeField.transform)
              {
              // Holder othernode = child.gameObject.GetComponent<Holder>()
              lineData = child.gameObject.GetComponent<storenodes>();
              // // INode otherNodeData = othernode.node;
              // if (lineData == null && othernode == null) continue;
              // else if (lineData.containsNode(parentNode))
              // {
              //     Destroy(lineData.gameObject);
              // }
              // else if (othernode != null && othernode.node.Output == parentNode.GetComponent<Holder>().node)
              // {
              //     othernode.node.Output = null;
              // }
              Debug.Log(child.gameObject);
                parentdestroyable.deleteInput(child.gameObject);

                if (lineData != null && lineData.containsNode(this.gameObject))
                {
                    Destroy(lineData.gameObject);
                }

              }
              parentNode.GetComponent<Holder>().node.Input = null;
          }
          else if (this.gameObject.name.Contains("Output"))
          {
            foreach (Transform child in nodeField.transform)
              {
              lineData = child.gameObject.GetComponent<storenodes>();
              parentNode.GetComponent<Holder>().node.Output = null;
              parentdestroyable.deleteOutput(child.gameObject);
                if (lineData != null && lineData.containsNode(this.gameObject))
                {
                    Destroy(lineData.gameObject);
                }
              }
          }
      }
    }
}
