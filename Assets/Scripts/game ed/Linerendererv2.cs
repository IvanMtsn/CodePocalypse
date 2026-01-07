using UnityEngine;

public class Linerendererv2 : MonoBehaviour
{
  [SerializeField] private LineRenderer lr;
  private Transform[] points;

  private void Awake(){
    lr = GetComponent<LineRenderer>();
    if (lr != null) lr.widthMultiplier = 1f;
  }

  public void SetUpLine(Transform[] points){
    this.points = points;
    if (lr != null && points != null) lr.positionCount = points.Length;
  }

  public Transform[] Points => points;

  private void Update(){
    if (points == null || lr == null) return;
    for(int i = 0; i < points.Length; i++){
      if (points[i] != null) lr.SetPosition(i, points[i].position);
    }
  }
}
