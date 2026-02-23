using UnityEngine;
using System.Collections.Generic;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject Content;
    [SerializeField] AudioClip ButtonEffekt;
    [SerializeField] AudioClip NodeConnectEffekt;
    [SerializeField] GameObject nodefield;
    Linerendererv2[] allLines;

    private GameObject firstbutton;

    public void Start()
    {
    }

    public void CreateLine(GameObject button)
    {
       if (button.transform.parent.GetComponent<DragAndDrop>().placed == true)
       {
        if (firstbutton == null)
        {
            firstbutton = button;
            SoundManager.instance.PlaySoundCLip(ButtonEffekt, 1f);
        }
        else
        {
            if (button == firstbutton)
            {
              firstbutton = null;
                Debug.Log("Same button clicked twice, line not created.");
              return;
            }
            GameObject newLine = Instantiate(linePrefab, Content.transform);
            Linerendererv2 lineRenderer = newLine.GetComponent<Linerendererv2>();
            Transform[] points = new Transform[2];
            points[0] = firstbutton.transform;
            points[1] = button.transform;
            // firstbutton.SetOutput(button);
            if(firstbutton.name.Contains("OutputSide"))
            {
              (firstbutton.transform.parent.GetComponent<Holder>().node as IfNode).Output2 = button.transform.parent.GetComponent<Holder>().node;
            }
            else
            {
              firstbutton.transform.parent.GetComponent<Holder>().node.Output = button.transform.parent.GetComponent<Holder>().node;
            }
            if(button.transform.parent.GetComponent<Holder>().node is IfNode)
            {
               
              if(button.transform.parent.GetComponent<Holder>().node.Input == null)
              {
                 button.transform.parent.GetComponent<Holder>().node.Input = firstbutton.transform.parent.GetComponent<Holder>().node;
              }
              else if(button.transform.parent.GetComponent<Holder>().node is IfNode ifNode && ifNode.Input2 == null && button.transform.parent.GetComponent<Holder>().node.Input != null)
              {
                 (button.transform.parent.GetComponent<Holder>().node as IfNode).Input2 = firstbutton.transform.parent.GetComponent<Holder>().node;
              }
              else
              {
                Debug.Log("Both inputs of the IfNode are already occupied, line not created.");
                Destroy(newLine);
                return;
              }
            }
            else
            {
               button.transform.parent.GetComponent<Holder>().node.Input = firstbutton.transform.parent.GetComponent<Holder>().node;
            }
            lineRenderer.SetUpLine(points);
            
            allLines = Content.GetComponentsInChildren<Linerendererv2>();
            firstbutton = null;
            SoundManager.instance.PlaySoundCLip(NodeConnectEffekt, 1f);
        }
       }
    }

    public void ClearAllLines()
    {
        allLines = Content.GetComponentsInChildren<Linerendererv2>();
        foreach (Linerendererv2 line in allLines)
        {
            Destroy(line.gameObject);
        }
    }
    
    
}