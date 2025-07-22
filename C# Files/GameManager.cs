using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager
{
    public int cakeCollected = 0;
    public int liveCount = 3;
    public int levelNum = 1;
    public int timer = (int)2 * (levelNum * 0.5);
    public int savedTime = 0;
    public int cakeNeeded = levelNum * 3;
    public bool gameStatus = false;
    public string[] objects = { "cake_slice", "cake_slice", "plane", "cloud" };
    public Random random = new Random();


    static void startGame() {
        gameStatus = true;
        generate("duck");
    }

    static void pauseGame() {
        gameStatus = false;
        savedTime = timer;

    }

    static void resumeGame() {
        gameStatus = true;
        timer = savedTime;
    }

    static void generate(string gameObject) {
        
    }

    static void generateRandom() {
        generate(objects[random.Next(0, 3)]);
    }

    static void updateTimer() {

    }

    static void updateLifeCount() {
        lives--;
    }

    static void updateCakeSliceCount() {
        cakeCollected++;
    }

    static void checkLevelCompleted() {
        if (cakeCollected == cakeNeeded && timer != 0 && lives > 0) {
            advanceToNextLevel();
        } else {
            displayScreen("Lose");
        }
    }

    static void resetGame() {
        levelNum = 1;
        resetLives();
    }

    static void displayHUD() {

    }

    static void advanceToNextLevel() {
        if (levelNum < 3) {
            levelNum++;
            resetValues();
        } else {
            displayScreen("Win");
        }
    }

    static void levelManager() {

    }

    static void buildCake() {

    }

    static void resetValues() {
        liveCount = 3;
        cakeCollected = 0;
        timer = (int)2 * (levelNum * 0.5);
        cakeNeeded = levelNum * 3;
    }

    static void displayScreen(string screen) {
        switch (screen)
        {
            case "Win":
                break;
            case "Lose":
                break;
        }
    }
}
