using TMPro;
using UnityEngine;

public class DivideNode_Holder : Holder
{
    [SerializeField] protected TMP_Text val1, val2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new DivideNode
        {
            val1 = val1,
            val2 = val2
        };
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
