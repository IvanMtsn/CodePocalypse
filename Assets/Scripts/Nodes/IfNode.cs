using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum Conditions
{
    WayIsBlocked,
    OnObjective
}
public class IfNode : MonoBehaviour, INode
{
    [SerializeField] GameObject Player;
    public NodeConnection Input { get; set; }
    public NodeConnection Output { get; set; }
    public NodeConnection Output2 { get; set; }
    public bool IsTrue { get; set; }

    public Conditions conditionType;

    ICondition condition;

    public async void RunNode()
    {
        CheckCondition();
        await Task.Yield();
    }

    public void CheckCondition()
    {
        condition = conditionType switch
        {
            (Conditions.WayIsBlocked) =>
            gameObject.GetComponent(typeof(WayBlockedCondition)) as WayBlockedCondition,
            (Conditions.OnObjective) =>
            gameObject.GetComponent(typeof(OnObjectiveCondition)) as OnObjectiveCondition,
            _ => null,
        };
        if (condition.Check(Player.transform))
        {
            IsTrue = true;
        }
        else IsTrue = false;
        Debug.Log($"Is True: {IsTrue}, Check: {condition.Check(Player.transform)}");
    }
    public void TestNode()
    {
        RunNode();
    }

    public NodeConnection GetOutput()
    {
        if (IsTrue) return Output;
        return Output2;
    }

    public void Stop()
    {
        //NA
    }
}
