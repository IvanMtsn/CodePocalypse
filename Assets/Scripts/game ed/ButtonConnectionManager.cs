using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonConnectionManager : MonoBehaviour
{
    [Header("Settings")]
    public GameObject linePrefab;
    public Color lineColor = Color.white;
    public float lineWidth = 0.05f;
    
    [Header("Connected Buttons")]
    public List<Button> connectableButtons = new List<Button>();
    
    private List<Button> selectedButtons = new List<Button>();
    private LineRenderer currentLine;
    private GameObject currentLineObject;

    void Start()
    {
        // Event-Listener für alle Buttons hinzufügen
        foreach (Button button in connectableButtons)
        {
            button.onClick.AddListener(() => OnButtonClicked(button));
        }
    }

    void OnButtonClicked(Button clickedButton)
    {
        // Prüfen ob Button bereits selektiert ist
        if (selectedButtons.Contains(clickedButton))
        {
            // Button abwählen
            selectedButtons.Remove(clickedButton);
            ResetButtonAppearance(clickedButton);
        }
        else
        {
            // Button hinzufügen
            selectedButtons.Add(clickedButton);
            HighlightButton(clickedButton);
        }

        // Linienlogik
        UpdateLineConnection();
    }

    void UpdateLineConnection()
    {
        // Alte Linie löschen wenn nötig
        if (currentLineObject != null)
        {
            Destroy(currentLineObject);
            currentLine = null;
        }

        // Wenn genau 2 Buttons selektiert sind, Linie erstellen
        if (selectedButtons.Count == 2)
        {
            CreateLineBetweenButtons(selectedButtons[0], selectedButtons[1]);
        }
        else if (selectedButtons.Count > 2)
        {
            // Bei mehr als 2 Buttons: Nur die letzten beiden behalten
            Button oldButton = selectedButtons[0];
            selectedButtons.RemoveAt(0);
            ResetButtonAppearance(oldButton);
            CreateLineBetweenButtons(selectedButtons[0], selectedButtons[1]);
        }
    }

    void CreateLineBetweenButtons(Button button1, Button button2)
    {
        // Line Renderer GameObject erstellen
        currentLineObject = new GameObject("ConnectionLine");
        currentLine = currentLineObject.AddComponent<LineRenderer>();

        // Line Renderer konfigurieren
        ConfigureLineRenderer(currentLine);
        
        // Positionen setzen
        Vector3 pos1 = button1.transform.position;
        Vector3 pos2 = button2.transform.position;
        
        // Z-Position anpassen damit Linie vor UI sichtbar ist
        pos1.z = -1f;
        pos2.z = -1f;
        
        currentLine.positionCount = 2;
        currentLine.SetPosition(0, pos1);
        currentLine.SetPosition(1, pos2);
    }

    void ConfigureLineRenderer(LineRenderer lr)
    {
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.sortingOrder = 1; // Über UI anzeigen
        
        // Glattere Ecken
        lr.numCornerVertices = 5;
        lr.numCapVertices = 5;
    }

    void HighlightButton(Button button)
    {
        // Button visuell hervorheben
        ColorBlock colors = button.colors;
        colors.normalColor = Color.green;
        colors.selectedColor = Color.green;
        button.colors = colors;
    }

    void ResetButtonAppearance(Button button)
    {
        // Button auf Standard zurücksetzen
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        button.colors = colors;
    }

    // Öffentliche Methode um alle Verbindungen zurückzusetzen
    public void ClearAllConnections()
    {
        selectedButtons.Clear();
        
        foreach (Button button in connectableButtons)
        {
            ResetButtonAppearance(button);
        }
        
        if (currentLineObject != null)
        {
            Destroy(currentLineObject);
            currentLine = null;
        }
    }
}