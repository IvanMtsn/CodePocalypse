using UnityEngine;

public interface INode
{
    //Ich nehme an du erstellst eine Klasse für die Verbindung zwischen den Nodes
    //NodeConnection input;
    //NodeConnection output;

    //Könnte sein das der Rückgabetyp geändert werden muss
    public void RunNode();

    //Hier könnte man eine Funktion zB GoNext machen, welche die nächste (Node am output) ausführt
    //zb public void GoNext();

    //Oder das (Noden-)Interaktionssystem liest die outputNode und führt RunNode für diese aus
}
