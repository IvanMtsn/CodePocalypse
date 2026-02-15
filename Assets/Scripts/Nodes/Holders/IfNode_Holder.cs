using UnityEngine;

public class IfNode_Holder : Holder
{
    public GameObject Player;
    public LayerMask obstacles, objective;

    void Awake()
    {
        node = new IfNode(Player);
        ((IfNode)node).obstacles = obstacles;
        ((IfNode)node).objective = objective;
    }

    public void TestNode()
    {
        node.RunNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDirectionDropdownChanged(int value)
    {
        ((IfNode)node).conditionType = (Conditions)value;
    }
}
