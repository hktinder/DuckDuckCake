using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen = null;
    private bool paused = false;
    public void PauseGame(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
        paused = isPaused;
    }

    void Update()
    {
        pauseScreen.SetActive(paused);
    }
}

