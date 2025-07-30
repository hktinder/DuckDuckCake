using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    /*
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public int levelNum;
    public static GameObject pauseObject;
    public static GameObject timer;

    public MonoBehaviour timerScript = timer.GetComponent<MonoBehaviour>();

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateGameState("Level" + levelNum);
    }

    void Update()
    {

    }

    public void ResumeGame()
    {
        pauseObject.SetActive(false);
        timerScript.SendMessage("Play");
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.Level1:
                break;
            case GameState.Level2:
                break;
            case GameState.Level3:
                break;
            case GameState.Pause:
                pauseObject.SetActive(true);
                timerScript.SendMessage("Pause");
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        if (OnGameStateChanged != null)
        {
            OnGameStateChanged(newState);
        }
    }*/
}

public enum GameState
{
    Level1,
    Level2,
    Level3,
    Pause,
    Win,
    Lose
}
