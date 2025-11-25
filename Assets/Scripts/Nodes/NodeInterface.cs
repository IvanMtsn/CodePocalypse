using System.Threading.Tasks;
using UnityEngine;

public interface INode
{
    NodeConnection Input { get; set; }
    NodeConnection Output { get; set; }


    //Könnte sein das der Rückgabetyp geändert werden muss
    public abstract void RunNode();
    public abstract void Stop();

    //Hier könnte man eine Funktion zB GoNext machen, welche die nächste (Node am output) ausführt
    //zb public void GoNext();

    //Oder das (Noden-)Interaktionssystem liest die outputNode und führt RunNode für diese aus
}
