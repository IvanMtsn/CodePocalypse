using UnityEngine;

public class OnObjectiveCondition : ICondition
{
    [SerializeField] LayerMask colliderMask;
    //Transform Player;

    public OnObjectiveCondition(LayerMask objectiveMask)
    {
        colliderMask = objectiveMask;
    }

    public bool Check(Transform Player)
    {
        return Physics.CheckSphere(Player.position, 0.4f, colliderMask.value);
    }
}
