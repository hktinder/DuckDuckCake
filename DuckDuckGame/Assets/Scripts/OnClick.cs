using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    [SerializeField] GameObject nextLevelScreen = null;
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

    public void LoadNextLevelScreen(bool click)
    {
        nextClicked = click;
        nextLevelScreen.SetActive(click);
    }

    void Update()
    {
        if (nextLevelScreen != null)
        {
            nextLevelScreen.SetActive(nextClicked);
        }
    }
}
