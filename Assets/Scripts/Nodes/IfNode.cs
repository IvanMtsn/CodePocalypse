using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum Conditions
{
    WayIsBlocked,
    OnObjective
}
public class IfNode : INode
{
    
    [SerializeField] GameObject Player;
    public INode Input { get; set; }
    public INode Input2 { get; set; }
    public INode Output { get; set; }
    public INode Output2 { get; set; }
    public bool IsTrue { get; set; }

    public Conditions conditionType;

    ICondition condition;

    public LayerMask obstacles, objective;

    public IfNode(GameObject player)
    {
        Player = player;
    }

    public async Task RunNode()
    {
        CheckCondition();
        await Task.Yield();
    }

    public void CheckCondition()
    {
        Debug.Log("Checking");
        condition = conditionType switch
        {
            (Conditions.WayIsBlocked) =>
            new WayBlockedCondition(obstacles),
            (Conditions.OnObjective) =>
            new OnObjectiveCondition(objective),
            _ => null,
        };
        condition.Check(Player.transform);
        IsTrue = condition.Check(Player.transform);
        Debug.Log($"Is True: {IsTrue}");
    }

    public INode GetOutput()
    {
        if (IsTrue) return Output;
        return Output2;
    }

    public void Stop()
    {
        //NA
    }
}
