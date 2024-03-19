using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerMenu : MonoBehaviour
{
    private Button archerButton;
    private Button swordButton;
    private Button wizardButton;
    private Button upgradeButton;
    private Button destroyButton;

    private VisualElement root;

    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        archerButton = root.Q<Button>("archer-button");
        swordButton = root.Q<Button>("sword-button");
        wizardButton = root.Q<Button>("wizard-button");
        upgradeButton = root.Q<Button>("button-upgrade");
        destroyButton = root.Q<Button>("button-destroy");

        if (archerButton != null)
        {
            archerButton.clicked += OnArcherButtonClicked;
        }

        if (swordButton != null)
        {
            swordButton.clicked += OnSwordButtonClicked;
        }

        if (wizardButton != null)
        {
            wizardButton.clicked += OnWizardButtonClicked;
        }

        if (upgradeButton != null)
        {
            upgradeButton.clicked += OnUpdateButtonClicked;
        }

        if (destroyButton != null)
        {
            destroyButton.clicked += OnDestroyButtonClicked;
        }

        root.visible = false;
    }

    private void OnArcherButtonClicked()
    {
        // Voer hier de acties uit wanneer op de Archer-knop wordt geklikt
    }

    private void OnSwordButtonClicked()
    {
        // Voer hier de acties uit wanneer op de Sword-knop wordt geklikt
    }

    private void OnWizardButtonClicked()
    {
        // Voer hier de acties uit wanneer op de Wizard-knop wordt geklikt
    }

    private void OnUpdateButtonClicked()
    {
        // Voer hier de acties uit wanneer op de Update-knop wordt geklikt
    }

    private void OnDestroyButtonClicked()
    {
        // Voer hier de acties uit wanneer op de Destroy-knop wordt geklikt
    }

    private void OnDestroy()
    {
        if (archerButton != null)
        {
            archerButton.clicked -= OnArcherButtonClicked;
        }

        if (swordButton != null)
        {
            swordButton.clicked -= OnSwordButtonClicked;
        }

        if (wizardButton != null)
        {
            wizardButton.clicked -= OnWizardButtonClicked;
        }

        if (upgradeButton != null)
        {
            upgradeButton.clicked -= OnUpdateButtonClicked;
        }

        if (destroyButton != null)
        {
            destroyButton.clicked -= OnArcherButtonClicked;
        }
    }
}
