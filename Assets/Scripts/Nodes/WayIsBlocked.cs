using UnityEngine;

public class WayIsBlocked : MonoBehaviour, ICondition
{
    public Transform Player;
    public Transform facingPoint;
    public bool Check()
    {
        Debug.Log($"Vector(1,0,0) + Vector(1,1,0) = {Vector3.right + new Vector3(1, 1, 0)}");
        Debug.Log($"Player: {Player.transform.position}, facingPoint{facingPoint.position}");
        return Physics.CheckBox(facingPoint.position, new Vector3(1, 0.5f, 1), Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(facingPoint.position, new Vector3(1, 1, 1));
    }
}
