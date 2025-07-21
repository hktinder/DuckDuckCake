using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{

    // constants 
    public float duckSpeed = 5;
    public float moveSpeed = 6;
    public float rightBound = -5.5f;
    public float leftBound = -5.5f;
    public float upBound = 4f;
    public float downBound = -1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
{
    transform.Translate(Vector3.forward * Time.deltaTime * duckSpeed, Space.World);

    if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < upBound)
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
    }
    else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > downBound)
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, Space.World);
    }

    if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftBound)
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
    }
    else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightBound)
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
    }
}

}
