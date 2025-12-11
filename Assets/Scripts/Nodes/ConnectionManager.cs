using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    private void OnDestroy()
    {
        INode node = GetComponent<INode>();
        //Hat die Node eine Verbindung am Input wird beim Zerstören dieser Node, die Outputverbindung der verbundenen Node gelöscht
        //TLTR Die Node vor dieser Node trennt die Verbindung
        if(node.Input.InputNode != null)
        {
            node.Input.InputNode.Output = null;
        }

        //Hat die Node eine Verbindung am Output wird beim Zerstören dieser Node, die Inputverbindung der verbundenen Node gelöscht
        //TLTR Die Node nach dieser Node trennt die Verbindung
        if (node.Output.OutputNode != null)
        {
            node.Output.OutputNode.Input = null;
        }
    }
}
