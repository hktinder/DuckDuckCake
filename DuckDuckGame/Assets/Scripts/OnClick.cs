using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    [SerializeField] GameObject nextScreen = null;
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
}
