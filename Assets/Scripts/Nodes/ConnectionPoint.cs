using UnityEngine;

public enum ConnectionType
{
    Input,
    Output,
    Sideinput
}

public class ConnectionPoint : MonoBehaviour
{
    [SerializeField] ConnectionType connectionType;
}
