using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject duckPrefab;
    public GameObject[] obstaclePrefabs; // 0: cake_slice, 1: plane, 2: cloud

    public int cakeCollected = 0;
    public int liveCount = 3;
    public int levelNum = 1;
    public float timer;
    private float savedTime = 0;
    public int cakeNeeded;
    public bool gameStatus = false;

    private float spawnInterval = 3f;
    private float timeSinceLastSpawn = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetValues();
        StartGame();
    }

    void Update()
    {
        if (!gameStatus) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            CheckLevelCompleted();
        }

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            GenerateRandom();
            timeSinceLastSpawn = 0f;
        }
    }

    public void StartGame()
    {
        gameStatus = true;
        Instantiate(duckPrefab, new Vector3(-7f, 1f, 0f), Quaternion.identity);
    }

    public void PauseGame()
    {
        gameStatus = false;
        savedTime = timer;
    }

    public void ResumeGame()
    {
        gameStatus = true;
        timer = savedTime;
    }

    public void Generate(string objectName)
    {
        GameObject prefabToSpawn = null;
        switch (objectName)
        {
            case "cake_slice":
                prefabToSpawn = obstaclePrefabs[0];
                break;
            case "plane":
                prefabToSpawn = obstaclePrefabs[1];
                break;
            case "cloud":
                prefabToSpawn = obstaclePrefabs[2];
                break;
        }

        if (prefabToSpawn != null)
        {
            Vector3 spawnPosition = new Vector3(10f, Random.Range(0f, 3f), 0f);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    public void GenerateRandom()
    {
        int randomIndex = Random.Range(0, 3);
        Generate(obstaclePrefabs[randomIndex].name);
    }

    public void UpdateTimer(float newTime)
    {
        timer = newTime;
    }

    public void UpdateLifeCount()
    {
        liveCount--;
        if (liveCount <= 0)
        {
            DisplayScreen("Lose");
        }
    }

    public void UpdateCakeSliceCount()
    {
        cakeCollected++;
        if (cakeCollected >= cakeNeeded)
        {
            CheckLevelCompleted();
        }
    }

    public void CheckLevelCompleted()
    {
        if (cakeCollected >= cakeNeeded && liveCount > 0 && timer > 0)
        {
            AdvanceToNextLevel();
        }
        else
        {
            DisplayScreen("Lose");
        }
    }

    public void ResetGame()
    {
        levelNum = 1;
        ResetValues();
    }

    public void AdvanceToNextLevel()
    {
        if (levelNum < 3)
        {
            levelNum++;
            ResetValues();
        }
        else
        {
            DisplayScreen("Win");
        }
    }

    public void ResetValues()
    {
        cakeCollected = 0;
        liveCount = 3;
        timer = 60f; // Example base timer for each level
        cakeNeeded = levelNum * 3;
        gameStatus = true;
    }

    public void DisplayScreen(string screen)
    {
        gameStatus = false;
        switch (screen)
        {
            case "Win":
                Debug.Log("You Win!");
                break;
            case "Lose":
                Debug.Log("You Lose!");
                break;
        }
    }
}
