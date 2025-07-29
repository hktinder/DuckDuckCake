using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
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
}
