using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    private void OnDestroy()
    {
        INode node = GetComponent<INode>();
        //Hat die Node eine Verbindung am Input wird beim Zerst�ren dieser Node, die Outputverbindung der verbundenen Node gel�scht
        //TLTR Die Node vor dieser Node trennt die Verbindung
        if(node.Input != null)
        {
            node.Input = null;
        }

        //Hat die Node eine Verbindung am Output wird beim Zerstren dieser Node, die Inputverbindung der verbundenen Node gelscht
        //TLTR Die Node nach dieser Node trennt die Verbindung
        if (node.Output != null)
        {
            node.Output = null;
        }
    }
}
