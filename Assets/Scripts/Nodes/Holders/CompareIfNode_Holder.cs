using TMPro;
using UnityEngine;

public class CompareIfNode_Holder : Holder
{
    CompareIfNode node;
    [SerializeField] TMP_Dropdown comparer;
    [SerializeField] TMP_Text val1, val2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new CompareIfNode();
        node.val1 = val1;
        node.val2 = val2;
        node.comparer = comparer;
    }
    public async void RunNode()
    {
        await node.RunNode();
    }
    public void SwitchComparer()
    {
        switch (comparer.value)
        {
            case 0: node.selectedComparer = CompareOptions.Smaller; break;
            case 1: node.selectedComparer = CompareOptions.SmallerOrEqual; break;
            case 2: node.selectedComparer = CompareOptions.Equal; break;
            case 3: node.selectedComparer = CompareOptions.GreaterOrEqual; break;
            case 4: node.selectedComparer = CompareOptions.Greater; break;
            case 5: node.selectedComparer = CompareOptions.Not; break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
