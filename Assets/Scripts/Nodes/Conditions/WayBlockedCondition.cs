using UnityEngine;

public class WayBlockedCondition : ICondition
{
    [SerializeField] LayerMask colliderMask;
    Vector3 facingPoint;

    public WayBlockedCondition(LayerMask obstacleMaks)
    {
        colliderMask = obstacleMaks;
    }

    public bool Check(Transform Player)
    {
        facingPoint = Player.position;
        facingPoint += -Player.up;
        return Physics.CheckBox(facingPoint, new Vector3(0.8f, 0.5f, 0.8f), Quaternion.identity, colliderMask.value);
    }
}
