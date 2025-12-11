using UnityEngine;

public class Linerendererv2 : MonoBehaviour
{
  [SerializeField] private LineRenderer lr;
  private Transform[] points;

  private void awake(){
    lr = GetComponent<LineRenderer>();
    lr.positionCount = 2;
    lr.widthMultiplier = 5f;
  }

  public void SetUpLine(Transform[] points){
    this.points = points;
  }

  public void Update(){
    for(int i = 0; i < points.Length; i++){
      lr.SetPosition(i, points[i].position);
    }
  }
}
