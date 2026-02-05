using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    public static GameObject objective;
    public static List<GameObject> collectedObjectives = new();

    List<GateObstacle> gates;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        gates = GameObject.FindObjectsByType<GateObstacle>(FindObjectsSortMode.None).ToList<GateObstacle>();
        Debug.Log(gates.Count + " Gates found.");
    }

    public void PickUpObjective()
    {
        Debug.Log(objective);
        if(objective)
        {
            objective.SetActive(false);
            collectedObjectives.Add(objective);
            Debug.Log($"Collected {collectedObjectives.Count} Objective(s).");
            foreach (GateObstacle g in gates)
            {
                g.OpenOrCloseGate();
            }
        }
    }
}
