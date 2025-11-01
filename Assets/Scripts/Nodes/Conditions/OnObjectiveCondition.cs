using UnityEngine;

public class OnObjectiveCondition : MonoBehaviour, ICondition
{
    [SerializeField] LayerMask colliderMask;
    public Transform Player;
    public bool Check(Transform Player)
    {
        return Physics.CheckSphere(this.Player.transform.position, 0.4f, colliderMask.value);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(Player.transform.position, 0.4f);
    }
}
