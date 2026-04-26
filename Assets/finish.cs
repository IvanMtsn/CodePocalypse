using UnityEngine;
using TMPro;

public class finish : MonoBehaviour
{
  [SerializeField] GameObject timerderzeit;
  [SerializeField] GameObject startRound;
  TextMeshProUGUI textMeshPro;
  SpielStart spielStart;

  void Start()
  {
    if (timerderzeit != null)
      textMeshPro = timerderzeit.GetComponent<TextMeshProUGUI>();
    if (startRound != null)
      spielStart = startRound.GetComponent<SpielStart>();
    
    SoundManager.instance.PlayLevelCompleteSound();
    

  }
  void Update()
  { 

  }
  void Awake(){
    if (timerderzeit != null)
    {
      Stopwatchmanager stopwatch = timerderzeit.GetComponent<Stopwatchmanager>();
      if (stopwatch != null)
      {
        stopwatch.OnLevelComplete();
      }
      else
      {
        Debug.LogError("Stopwatchmanager nicht gefunden auf timerderzeit!");
      }
    }
    else
    {
      Debug.LogError("timerderzeit ist null!");
    }
  }

}
