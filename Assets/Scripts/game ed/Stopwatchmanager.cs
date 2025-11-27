using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stopwatchmanager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button stopBtn;

    private float elapsedTime = 0f;
    private float lastTime = 0f;
    // private float bestTime = Mathf.Infinity;
    private bool isTiming = false;

    void Start()
    {
        startBtn.onClick.AddListener(StartTimer);
        stopBtn.onClick.AddListener(StopTimer);
    }

    void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    private void StartTimer()
    {
        isTiming = true;
        elapsedTime = 0f;
        startBtn.interactable = false;
        stopBtn.interactable = true;
    }

    private void StopTimer()
    {
        isTiming = false;
        startBtn.interactable = true;
        stopBtn.interactable = false;

        // Speichere Letzte Zeit
        lastTime = elapsedTime;

        // Überprüfe auf Bestzeit
        bool newBestTime = false;
        // if (elapsedTime < bestTime && elapsedTime > 0.1f)
        // {
        //     bestTime = elapsedTime;
        //     newBestTime = true;
        // }

        // Logge Zeiten
        Debug.Log($"Letzte Zeit: {FormatTime(lastTime)}");
        
        // if (bestTime < Mathf.Infinity)
        // {
        //         Debug.Log($"Bestzeit: {FormatTime(bestTime)}");

        // }
        // else
        // {
        //     Debug.Log("Bestzeit: Noch keine Bestzeit aufgezeichnet");
        // }
    }

    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 100) % 100);
        
        return $"{minutes:00}:{seconds:00}.{milliseconds:00}";
    }

    // // Public Methoden
    // public void ResetBestTime()
    // {
    //     bestTime = Mathf.Infinity;
    //     Debug.Log("Bestzeit zurückgesetzt");
    // }
}