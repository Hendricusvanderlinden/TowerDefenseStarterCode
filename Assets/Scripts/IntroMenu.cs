using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IntroMenu : MonoBehaviour
{
    private Button playButton;
    private Button quitButton;
    private TextField nameInput;

    private void Start()
    {
        // Haal de root VisualElement op
        var root = GetComponent<UIDocument>().rootVisualElement;
        Debug.Log("Root VisualElement: " + root);

        // Zoek de knoppen en het tekstveld in de root VisualElement
        playButton = root.Q<Button>("Play-Button");
        quitButton = root.Q<Button>("Quit-Button");
        nameInput = root.Q<TextField>("Name");

        // Controleer of de knoppen en het tekstveld zijn gevonden
        if (playButton != null)
            playButton.clicked += StartButtonClicked;
        else
            Debug.LogError("Start Button not found!");

        if (quitButton != null)
            quitButton.clicked += QuitButtonClicked;
        else
            Debug.LogError("Quit Button not found!");
    }

    private void OnDestroy()
    {
        // Verwijder de callbackfuncties om geheugenlekken te voorkomen
        if (playButton != null)
            playButton.clicked -= StartButtonClicked;

        if (quitButton != null)
            quitButton.clicked -= QuitButtonClicked;
    }

    private void StartButtonClicked()
    {
        // Laad de GameScene
        SceneManager.LoadScene("GameScene");
    }

    private void QuitButtonClicked()
    {
        // Sluit de game af
        Application.Quit();
    }
}