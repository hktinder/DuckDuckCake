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
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Update()
    {
        pauseScreen.SetActive(paused);
    }
}

