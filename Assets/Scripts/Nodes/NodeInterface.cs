using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public interface INode
{
    NodeConnection Input { get; set; }
    NodeConnection Output { get; set; }


    //K�nnte sein das der R�ckgabetyp ge�ndert werden muss
    public abstract void RunNode();
    public abstract void Stop();

    //Hier k�nnte man eine Funktion zB GoNext machen, welche die n�chste (Node am output) ausf�hrt
    //zb public void GoNext();

    //Oder das (Noden-)Interaktionssystem liest die outputNode und f�hrt RunNode f�r diese aus
}
