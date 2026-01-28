using TMPro;
using UnityEngine;

public class MultNode_Holder : MonoBehaviour
{
    public MultiplyNode node;
    [SerializeField] protected TMP_Text val1, val2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new MultiplyNode();
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
