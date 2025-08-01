using UnityEngine;

public static class GameStateManager
{
    public static int cakeCount = 0;
    public static float timer = 60f;
    public static int playerHealth = 3;

    public static float originalTimer = 90f;

    public static bool GameToLoad()
    {
        if (timer == originalTimer)
        {
            Debug.Log("Nothing to load...");
            return false;
        }
        else
        {
            Debug.Log("Something to load!");
            return true;
        }
    }


}
