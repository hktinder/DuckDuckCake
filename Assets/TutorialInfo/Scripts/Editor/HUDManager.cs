using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text timerText;
    public Text lifeText;
    public Text cakeText;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.gameStatus)
        {
            UpdateHUD();
        }
    }

    void UpdateHUD()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.CeilToInt(GameManager.Instance.timer)).ToString();
        lifeText.text = "Lives: " + GameManager.Instance.liveCount.ToString();
        cakeText.text = "Cake: " + GameManager.Instance.cakeCollected + "/" + GameManager.Instance.cakeNeeded;
    }
}
