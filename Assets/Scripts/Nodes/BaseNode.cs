using System.Threading.Tasks;
using UnityEngine;

public abstract class Node : MonoBehaviour 
{
    NodeConnection input;
    NodeConnection output;

    //Könnte sein das der Rückgabetyp geändert werden muss
    public abstract Task RunNode();

    //Hier könnte man eine Funktion zB GoNext machen, welche die nächste (Node am output) ausführt
    //zb public void GoNext();

    //Oder das (Noden-)Interaktionssystem liest die outputNode und führt RunNode für diese aus
}
