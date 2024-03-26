using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TopMenu : MonoBehaviour
{
    public UIDocument uiDocument;
    private VisualElement root;
    private Label waveLabel;
    private Label creditsLabel;
    private Label healthLabel;
    private Button startWaveButton;

    private GameManager gameManager;

    private void Start()
    {
        // Zoek de root VisualElement van de UIDocument
        root = uiDocument.rootVisualElement;

        // Zoek de labels en button in de UI-document hiërarchie
        waveLabel = root.Q<Label>("waveLabel");
        creditsLabel = root.Q<Label>("creditsLabel");
        healthLabel = root.Q<Label>("healthLabel");
        startWaveButton = root.Q<Button>("startWaveButton");

        // Controleer of de labels en button zijn gevonden
        if (waveLabel == null || creditsLabel == null || healthLabel == null || startWaveButton == null)
        {
            Debug.LogError("One or more UI elements not found in UI document!");
        }

        // Voeg een event listener toe aan de button
        startWaveButton.clicked += StartWave;
    }

    // Voeg hier je functie toe om een wave te starten
    private void StartWave()
    {
        if (gameManager != null)
        {
            gameManager.StartWave();
            DisableWaveButton();
        }
        else
        {
            Debug.LogWarning("GameManager not found!");
        }
    }

    // Voeg hier de functies toe om de labels aan te passen
    public void SetWaveLabel(string text)
    {
        if (waveLabel != null)
        {
            waveLabel.text = text;
        }
        else
        {
            Debug.LogWarning("WaveLabel not assigned!");
        }
    }

    public void SetCreditsLabel(string text)
    {
        if (creditsLabel != null)
        {
            creditsLabel.text = text;
        }
        else
        {
            Debug.LogWarning("CreditsLabel not assigned!");
        }
    }

    public void SetHealthLabel(string text)
    {
        if (healthLabel != null)
        {
            healthLabel.text = text;
        }
        else
        {
            Debug.LogWarning("HealthLabel not assigned!");
        }
    }

    // Voeg OnDestroy toe om de callback van de button te verwijderen
    private void OnDestroy()
    {
        startWaveButton.clicked -= StartWave;
    }

    public void EnableWaveButton()
    {
        if (startWaveButton != null)
        {
            startWaveButton.SetEnabled(true);
        }
        else
        {
            Debug.LogWarning("WaveButton not assigned!");
        }
    }

    private void DisableWaveButton()
    {
        if (startWaveButton != null)
        {
            startWaveButton.SetEnabled(false);
        }
        else
        {
            Debug.LogWarning("WaveButton not assigned!");
        }
    }
}