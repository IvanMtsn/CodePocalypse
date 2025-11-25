using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class CollectNode : MonoBehaviour, INode
{
    public NodeConnection Input { get; set; }
    public NodeConnection Output { get; set; }

    [SerializeField] GameObject Player;
    List<GateObstacle> gates;
    LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerMask = LayerMask.GetMask("Objective");
        gates = GameObject.FindObjectsByType<GateObstacle>(FindObjectsSortMode.None).ToList<GateObstacle>();
        Debug.Log(gates.Count + " Gates found.");
    }

    public async void RunNode()
    {
        await CollectObjective();
        await Task.Yield();
    }

    public async Task CollectObjective()
    {
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position-Player.transform.forward, Player.transform.forward, out hit, 1f, layerMask))
        {
            ObjectiveManager.Instance.PickUpObjective(hit.rigidbody.gameObject);
            foreach (GateObstacle g in gates)
            {
                g.OpenOrCloseGate();
            }
        }
        else { Debug.Log("Nothing hit."); }

        await Task.Yield();
    }

    public void TestNode()
    {
        RunNode();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(Player.transform.position - Player.transform.forward/2, Player.transform.position + Player.transform.forward/2);
    }

    public void Stop()
    {
        //NA
    }
}
