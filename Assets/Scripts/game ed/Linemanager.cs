using UnityEngine;
using System.Collections.Generic;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject Content;

    private GameObject firstbutton;

    public void CreateLine(GameObject button)
    {
        if (firstbutton == null)
        {
            firstbutton = button;
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
            lineRenderer.SetUpLine(points);
            firstbutton = null;
        }
    }
    
    
}