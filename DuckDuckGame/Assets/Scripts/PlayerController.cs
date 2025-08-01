using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float duckSpeed = 5;
    public float moveSpeed = 50;
    public int maxHealth = 3;
    public static int currentHealth;
    public HealthBar healthBar;
    public static int currentCakeSlices;
    public int totalCakeSlices;
    public CakeCount cakeCount;

    private Vector2 screenBounds;

    public bool paused = false;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log("Screenbounds- x: " + screenBounds.x + " y: " + screenBounds.y);
        currentHealth = GameStateManager.playerHealth;
        Debug.Log("Current Health: " + GameStateManager.playerHealth);
        healthBar.SetMaxHealth(maxHealth);
        currentCakeSlices = GameStateManager.cakeCount;
        cakeCount.UpdateCakeCount(currentCakeSlices);
    }

    void Update()
    {
        if (!paused)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * duckSpeed, Space.World);
            if (Input.GetKey(KeyCode.UpArrow) && this.gameObject.transform.position.y < -1 * screenBounds.y / 2)
            {
                animator.Play("Ascend");
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && this.gameObject.transform.position.y > screenBounds.y / 2)
            {
                animator.Play("Descend");
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, Space.World);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.position.x > screenBounds.x / 2)
            {
                animator.Play("FlapWings");
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.position.x < -1 * screenBounds.x / 2)
            {
                animator.Play("FlapWings");
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }
            else
            {
                animator.Play("Idle");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    public void AddSlice(int slice)
    {
        currentCakeSlices += slice;
        cakeCount.UpdateCakeCount(currentCakeSlices);
        if (currentCakeSlices == totalCakeSlices)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public static int GetHealthScore()
    {
        return currentHealth;
    }

    public static int GetCakeSlices()
    {
        return currentCakeSlices;
    }
}