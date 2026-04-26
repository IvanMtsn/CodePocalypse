using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stopwatchmanager : MonoBehaviour
{
   [SerializeField] private TMP_Text levelNameText;
   [SerializeField] private TMP_Text currentTime;
   [SerializeField] private TMP_Text bestTime;
    
    private float timer = 0f;
    private bool running = false;

    void Update()
    {
        if (running)
            timer += Time.deltaTime;
    }

    public void StartTimer() => running = true;
    public void StopTimer() => running = false;

    public void OnLevelComplete()
    {
        StopTimer();

        string levelName = levelNameText.text;
        float currentBest = PlayerPrefs.GetFloat("BestTime_" + levelName, float.MaxValue);
        string formattedTimer = FormatTime(timer);
        Debug.Log($"OnLevelComplete aufgerufen. Timer: {timer}, Formatted: {formattedTimer}");
        if (currentTime != null)
        {
            currentTime.text = formattedTimer;
            Debug.Log($"currentTime.text gesetzt auf: {currentTime.text}");
        }
        else
        {
            Debug.LogError("currentTime TMP_Text ist null!");
        }
        if (timer < currentBest)
        {
            PlayerPrefs.SetFloat("BestTime_" + levelName, timer);
            PlayerPrefs.Save();
            Debug.Log($"Neuer Rekord: {FormatTime(timer)}");
            bestTime.text = FormatTime(timer);
        }
        else
        {
            Debug.Log($"Bestzeit: {FormatTime(currentBest)}");
            bestTime.text = FormatTime(currentBest);
        }
    }

    public static string FormatTime(float seconds)
    {
        if (seconds == float.MaxValue) return "--:--.--";

        int minutes = (int)(seconds / 60);
        int secs    = (int)(seconds % 60);
        int ms      = (int)((seconds * 100) % 100);

        return $"{minutes:00}:{secs:00}.{ms:00}";
    }
}