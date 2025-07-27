using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float duckSpeed = 5;
    public float moveSpeed = 50;
    public float rightBound = 195f;
    public float leftBound = -204f;
    public float upBound = 275f;
    public float downBound = -127f;
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar;
    public int currentCakeSlices;
    public int totalCakeSlices;
    public CakeCount cakeCount;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        cakeCount.UpdateCakeCount(currentCakeSlices);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * duckSpeed, Space.World);
        if (Input.GetKey(KeyCode.UpArrow) && this.gameObject.transform.position.y < upBound)
        {
            animator.Play("Animation");
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && this.gameObject.transform.position.y > downBound)
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.position.x > leftBound)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.position.x < rightBound)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }
        /*else if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }*/
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    void AddSlice(int slice)
    {
        currentCakeSlices += slice;
        cakeCount.UpdateCakeCount(currentCakeSlices);
        if (currentCakeSlices == totalCakeSlices)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

}
