using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject nodeField;
    
    private Linerendererv2[] allLines;
    private GameObject firstButton;
    private GameObject firstNode;

    public void CreateLine(GameObject button)
    {
        if (!IsButtonPlaced(button)) return;

        if (firstButton == null)
        {
            if (button.gameObject.name.Contains("Output"))
            {
                firstButton = button;
                SetFirstButtonAlpha(0.5f);
                firstNode = button;
                SoundManager.instance.PlayMenuButtonSound();
            }

            return;
        }

        if (button == firstButton)
        {
            SetFirstButtonAlpha(0f);
            firstButton = null;
            firstNode = null;
            Debug.Log("Same button clicked twice, line not created.");
            return;
        }
        CreateLineBetweenButtons(firstButton, button);
    }



    public bool HasFirstButton => firstButton != null;

    private void SetFirstButtonAlpha(float alpha)
    {
        if (firstButton != null)
        {
            Image buttonImage = firstButton.GetComponent<Image>();
            if (buttonImage != null)
            {
                Color color = buttonImage.color;
                color.a = alpha;
                buttonImage.color = color;
            }
        }
    }

    private bool IsButtonPlaced(GameObject button)
    {
        DragAndDrop dragDrop = button.transform.parent.GetComponent<DragAndDrop>();
        return dragDrop != null && dragDrop.placed;
    }

    private void CreateLineSegment(Transform start, Transform end)
    {
        GameObject newLine = Instantiate(linePrefab, nodeField.transform);
        Linerendererv2 lineRenderer = newLine.GetComponent<Linerendererv2>();
        Transform[] points = { start, end };
        lineRenderer.SetUpLine(points);
        allLines = nodeField.GetComponentsInChildren<Linerendererv2>();
    }

    private void CreateLineBetweenButtons(GameObject start, GameObject end)
    {
        GameObject newLine = Instantiate(linePrefab, nodeField.transform);
        Linerendererv2 lineRenderer = newLine.GetComponent<Linerendererv2>();
        
        Transform[] points = { start.transform, end.transform };
        
        if (!ConnectNodes(start, end))
        {
            Destroy(newLine);
            return;
        }

        lineRenderer.SetUpLine(points);
        allLines = nodeField.GetComponentsInChildren<Linerendererv2>();
        SetFirstButtonAlpha(0f);
        firstButton = null;
        SoundManager.instance.PlayNodeConnectEffekt();
    }

    private bool ConnectNodes(GameObject start, GameObject end)
    {
        Holder startHolder = start.transform.parent.GetComponent<Holder>();
        Holder endHolder = end.transform.parent.GetComponent<Holder>();

        if (startHolder == null || endHolder == null) return false;

        // Set output
        if (start.name.Contains("OutputSide"))
        {
            if (startHolder.node is IfNode ifNode)
            {
                ifNode.Output2 = endHolder.node;
            }
        }
        else
        {
            startHolder.node.Output = endHolder.node;
        }

        // Set input
        if (endHolder.node is IfNode endIfNode)
        {
            if (endIfNode.Input == null)
            {
                endIfNode.Input = startHolder.node;
            }
            else if (endIfNode.Input2 == null)
            {
                endIfNode.Input2 = startHolder.node;
            }
            else
            {
                Debug.Log("Both inputs of the IfNode are already occupied, line not created.");
                return false;
            }
        }
        else if (endHolder.node is CompareIfNode compareIfNode)
        {
            if (end.name.Contains("SideInput1"))
            {
                compareIfNode.SideInput1 = startHolder.node;
            }
            else if (end.name.Contains("SideInput2"))
            {
                compareIfNode.SideInput2 = startHolder.node;
            }
            else
            {
                compareIfNode.Input = startHolder.node;
            }
        }
        else
        {
            endHolder.node.Input = startHolder.node;
        }

        return true;
    }

}
