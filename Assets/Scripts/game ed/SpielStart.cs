using System.Threading.Tasks;
using UnityEngine;

public class SpielStart : MonoBehaviour
{
    [SerializeField] GameObject StartNode;
    [SerializeField] GameObject EndNode;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject nodeSelection;
    [SerializeField] Panelschrink panel;
    [SerializeField] SoundManager soundManager;
    [SerializeField] MusikManager musicManager;
    bool gamestart = false;
    public float timer = 0f;
    public int DelayMS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(gamestart == true)
        {
            timer += Time.deltaTime;
        }
    }
    bool fullConnected()
    {
      if(StartNode.GetComponent<Holder>().node.Output != null && EndNode.GetComponent<Holder>().node.Input != null)
      {
        return true;
      }
      return false;
    }

    public void ResetGame()
    {
      gamestart = false;
    }
    

    public async void StartRound()
    {
      if (!fullConnected())
      {
        Debug.Log("Not all Nodes are connected!");
        return;
      }
      
      startButton.SetActive(false);
      nodeSelection.SetActive(false);
      soundManager.PlayPlayerStartSound();
      musicManager.PlayMusikAction();
      var currentNode = StartNode.GetComponent<Holder>().node;
      panel.ScaleAndMove();
      timer = 0f;
      gamestart = true;
      while (currentNode != null)
      {
         if(currentNode is IfNode)
         {
          await currentNode.RunNode();
          await Task.Delay(DelayMS);
          currentNode = ((IfNode)currentNode).GetOutput();
          Debug.Log("IfNode processed, moving to next node.");
          Debug.Log($"Next node: {currentNode}");
         }
         else
         {
          await currentNode.RunNode();
          await Task.Delay(DelayMS);
          currentNode = currentNode.Output;
         }
      }
        Debug.Log("No more Nodes");
    }
}
