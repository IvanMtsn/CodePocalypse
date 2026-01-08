using UnityEngine;
using UnityEngine.UI;

public class Output_Button : MonoBehaviour
{
    private Button outputButton;

    void Start() { }

    public void SetOutput(Button newOutput)
    {
        outputButton = newOutput;
        var parentNode = outputButton.transform.parent;
        if (parentNode != null)
            Debug.Log("Output button set to node: " + parentNode.name);
    }

    public void DelOutput()
    {
        outputButton = null;
    }
}
