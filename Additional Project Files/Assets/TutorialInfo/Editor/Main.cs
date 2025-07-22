using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public Button startButton;
    public Button howToPlayButton;
    public Button creditsButton;
    public Button quitButton;

    void Start()
    {
        if (startButton != null) startButton.onClick.AddListener(StartGame);
        if (howToPlayButton != null) howToPlayButton.onClick.AddListener(ShowHowToPlay);
        if (creditsButton != null) creditsButton.onClick.AddListener(ShowCredits);
        if (quitButton != null) quitButton.onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        // Assuming your game scene is named "GameScene"
        SceneManager.LoadScene("GameScene");
    }

    public void ShowHowToPlay()
    {
        // Load the HowToPlay scene or panel
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void ShowCredits()
    {
        // Load the Credits scene or panel
        SceneManager.LoadScene("CreditsScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
