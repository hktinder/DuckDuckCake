using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float playerSpeed = 1000;
    public float horizontalSpeed = 1000;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.position.x > leftLimit)
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.transform.position.x < rightLimit)
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * horizontalSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * horizontalSpeed * -1);
        }
    }
}
