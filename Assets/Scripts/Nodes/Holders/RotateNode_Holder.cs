using TMPro;
using UnityEngine;

public class RotateNode_Holder : Holder
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject destination;
    [SerializeField] TMP_Dropdown Dropdown;
    public int RotateSpeed;
    [SerializeField] RotateDirection selectedDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new RotateNode(Player);
        ((RotateNode)node).RotateSpeed = RotateSpeed;
        ((RotateNode)node).destination = destination;
        ((RotateNode)node).selectedDir = selectedDir;    
    }
    public async void RunNode()
    {
        await node.RunNode();
    }

    public void OnDirectionDropdownChanged()
    {
        Debug.Log((RotateDirection)Dropdown.value);
        selectedDir = (RotateDirection)Dropdown.value;
        ((RotateNode)node).selectedDir = (RotateDirection)Dropdown.value;
    }
}
