using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IfNode_Holder : Holder
{
    [SerializeField] TMP_Dropdown Dropdown;

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

    public void OnDirectionDropdownChanged()
    {
        ((IfNode)node).conditionType = (Conditions)Dropdown.value;
    }
}
