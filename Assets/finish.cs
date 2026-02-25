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
  }
  void Update()
  { 
    if (textMeshPro != null && spielStart != null)
      textMeshPro.text = spielStart.timer.ToString("F2") + " Sec";
  }
}
