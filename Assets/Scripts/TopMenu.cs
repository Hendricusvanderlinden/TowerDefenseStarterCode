using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopMenu : MonoBehaviour
{
    public UIDocument uiDocument;

    private Label wave;
    private Label credits;
    private Label health;
    private Button startWave;

    private VisualElement root;
    void Awake()
    {
        // Root element verkrijgen
        root = GetComponent<UIDocument>().rootVisualElement;
    }
    void Start()
    {
        // Zoek de labels en button in de UI-document hiërarchie
        wave = uiDocument.rootVisualElement.Q<Label>("wave");
        credits = uiDocument.rootVisualElement.Q<Label>("credits");
        health = uiDocument.rootVisualElement.Q<Label>("health");
        startWave = uiDocument.rootVisualElement.Q<Button>("startwave");

        // Controleer of de labels en button zijn gevonden
        if (wave == null || credits == null || health == null || startWave == null)
        {
            Debug.LogError("One or more UI elements not found in UI document!");
        }

        // Voeg een event listener toe aan de button
        startWave.clicked += StartWave;
    }

    // Voeg hier je functie toe om een wave te starten
    void StartWave()
    {
        // Voeg hier de logica toe om een wave te starten
    }

    // Voeg hier de functies toe om de labels aan te passen
    public void SetWaveLabel(string text)
    {
        wave.text = text;
    }

    public void SetCreditsLabel(string text)
    {
        credits.text = text;
    }

    public void SetHealthLabel(string text)
    {
        health.text = text;
    }

    // Voeg OnDestroy toe om de callback van de button te verwijderen
    void OnDestroy()
    {
        startWave.clicked -= StartWave;
    }
}
