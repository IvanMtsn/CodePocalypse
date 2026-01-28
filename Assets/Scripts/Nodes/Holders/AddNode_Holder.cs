using TMPro;
using UnityEngine;

public class AddNode_Holder : MonoBehaviour
{
    public AddNode node;
    [SerializeField] protected TMP_Text val1, val2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new AddNode();
        node.val1 = val1;
        node.val2 = val2;
    }
    public async void RunNode()
    {
        await node.RunNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
