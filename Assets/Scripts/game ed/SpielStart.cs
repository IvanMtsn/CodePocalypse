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
    public INode CurrentNode;
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
    bool FullConnected()
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
        CurrentNode?.Stop();
        CurrentNode = null;
    }
    

    public async void StartRound()
    {
      if (!FullConnected())
      {
        Debug.Log("Not all Nodes are connected!");
        return;
      }
      
      startButton.SetActive(false);
      nodeSelection.SetActive(false);
      soundManager.PlayPlayerStartSound();
      musicManager.PlayMusikAction();
      CurrentNode = StartNode.GetComponent<Holder>().node;
      panel.ScaleAndMove();
      timer = 0f;
      gamestart = true;
      while (CurrentNode != null)
      {
        //if(CurrentNode == null) return;
         if(CurrentNode is IfNode)
         {
          await CurrentNode.RunNode();
          await Task.Delay(DelayMS);
          CurrentNode = ((IfNode)CurrentNode).GetOutput();
          Debug.Log("IfNode processed, moving to next node.");
          Debug.Log($"Next node: {CurrentNode}");
         }
         else
         {
            //Debug.Log(CurrentNode.ToString());
            await CurrentNode.RunNode();
            await Task.Delay(DelayMS);
            if(CurrentNode == null) break;
            CurrentNode = CurrentNode.Output;
            //Debug.Log("New cur: " + CurrentNode.ToString());
         }
      }
        Debug.Log("No more Nodes");
    }
}
