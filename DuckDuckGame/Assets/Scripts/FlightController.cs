using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public Animator animator;
    public float duckSpeed = 5;
    public float moveSpeed = 6;
    public float rightBound = 5.5f;
    public float leftBound = -5.5f;
    public float upBound = 4f;
    public float downBound = -1f;


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
        else if (Input.GetKey(KeyCode.RightArrow)  && this.gameObject.transform.position.x < rightBound)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }
    }

}
