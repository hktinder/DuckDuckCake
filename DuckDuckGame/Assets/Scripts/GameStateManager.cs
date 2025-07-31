using UnityEngine;

public static class GameStateManager
{
    public static int cakeCount;
    public static float timer;
    public static int playerHealth;

    public static int originalTimer;

    public static bool gameToLoad()
    {
        if (timer == originalTimer)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}
