using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen = null;
    private bool paused = false;
    public void PauseGame(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
        paused = isPaused;
    }

    public void LoadHomePage(bool saveData)
    {
        if (!saveData)
        {
            GameStateManager.cakeCount = 0;
            GameStateManager.timer = 90f;
            GameStateManager.playerHealth = 3;
            Debug.Log("Didn't save data...");
        }
        else
        {
            Debug.Log(PlayerController.GetCakeSlices());
            Debug.Log(Timer.GetRemainingTime());
            Debug.Log(PlayerController.GetHealthScore());
            GameStateManager.cakeCount = PlayerController.GetCakeSlices();
            GameStateManager.timer = Timer.GetRemainingTime();
            GameStateManager.playerHealth = PlayerController.GetHealthScore();
            Debug.Log("Saved data!");
        }
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        pauseScreen.SetActive(paused);
    }
}

