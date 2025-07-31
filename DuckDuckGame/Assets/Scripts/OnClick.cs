using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    [SerializeField] GameObject nextScreen = null;
    [SerializeField] GameObject secondaryScreen = null;
    public bool nextClicked = false;
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadHomePage()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    public void LoadEndScreen()
    {
        Application.Quit();
    }

    public void LoadNextScreen(bool click)
    {
        nextClicked = click;
        nextScreen.SetActive(click);
    }

    void Update()
    {
        if (nextScreen != null)
        {
            nextScreen.SetActive(nextClicked);
        }
    }

    public void CheckGameLoad()
    {
        if (GameStateManager.GameToLoad())
        {
            nextScreen.SetActive(true);
            Debug.Log("Opened prompt for info");
        }
        else
        {
            secondaryScreen.SetActive(true);
            Debug.Log("Skipped prompt");
            Debug.Log(GameStateManager.playerHealth);
            Debug.Log(GameStateManager.timer);
            Debug.Log(GameStateManager.cakeCount);
        }
    }

    public void LoadNewGame(bool newGame)
    {
        if (newGame)
        {
            GameStateManager.playerHealth = 3;
            GameStateManager.timer = 90f;
            GameStateManager.cakeCount = 0;
        }
    }
}
