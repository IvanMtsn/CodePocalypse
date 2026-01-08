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
    List<GameObject> allnodes;

    private GameObject firstbutton;

    public void Start()
    {
        allnodes = new List<GameObject>();
    }

    public void CreateLine(GameObject button)
    {
        getNodes();
        if (firstbutton == null)
        {
            firstbutton = button;
            // SoundManager.instance.PlaySoundCLip(ButtonEffekt, 1f);
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
            firstbutton.transform.parent.GetComponent<INode>().Output = button.transform.parent.GetComponent<INode>();
            button.transform.parent.GetComponent<INode>().Input = firstbutton.transform.parent.GetComponent<INode>();
            lineRenderer.SetUpLine(points);
            
            allLines = Content.GetComponentsInChildren<Linerendererv2>();
            firstbutton = null;
            // SoundManager.instance.PlaySoundCLip(NodeConnectEffekt, 1f);
        }
    }

    public void getNodes()
    {
      allnodes.Clear();
      Transform parent = nodefield.transform;
      foreach (Transform child in parent)
      {
          if (child.gameObject.CompareTag("Node"))
          {
              allnodes.Add(child.gameObject);
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