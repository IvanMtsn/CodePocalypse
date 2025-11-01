using UnityEngine;

public class WayBlockedCondition : MonoBehaviour, ICondition
{
    [SerializeField] LayerMask colliderMask;
    Vector3 facingPoint;

    public bool Check(Transform Player)
    {
        facingPoint = Player.transform.position;
        facingPoint += Player.transform.forward;
        return Physics.CheckBox(facingPoint, new Vector3(0.8f, 0.5f, 0.8f), Quaternion.identity, colliderMask.value);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(facingPoint, new Vector3(0.8f, 0.5f, 0.8f));
    }
}
