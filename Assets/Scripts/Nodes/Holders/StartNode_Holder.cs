using UnityEngine;

public class StartNode_Holder : Holder
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        node = new StartNode(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
