using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    public static List<GameObject> collectedObjectives = new();

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUpObjective(GameObject objective)
    {
        if(objective.layer == 6)
        {
            objective.SetActive(false);
            collectedObjectives.Add(objective);
            Debug.Log($"Collected {collectedObjectives.Count} Objective(s).");
        }
    }
}
