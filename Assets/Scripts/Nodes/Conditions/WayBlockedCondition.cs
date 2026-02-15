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
        facingPoint = Player.transform.position;
        facingPoint += -Player.transform.up;
        Debug.Log($"Masks: {colliderMask.value}, {colliderMask}");
        Debug.Log(Physics.CheckBox(facingPoint, new Vector3(0.8f, 0.5f, 0.8f), Quaternion.identity, colliderMask.value));
        return Physics.CheckBox(facingPoint, new Vector3(0.8f, 0.5f, 0.8f), Quaternion.identity, colliderMask.value);
    }
}
