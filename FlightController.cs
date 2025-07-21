using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FlightController : MonoBehavior
{
    public float duckSpeed = 5;
    public float moveSpeed = 6;
    public float rightBound = -5.5f;
    public float leftBound = -5.5f;
    public float upBound = 4f;
    public float downBound = -1f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * duckSpeed, Space.World);

        if (input.GetKey(KeyCode.UpArrow) && this.gameObject.transform.postion.z > upBound)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (input.GetKey(KeyCode.DownArrow) && this.gameObject.transform.postion.z > downBound)
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (input.GetKey(KeyCode.LeftArrow) && this.gameObject.transform.postion.x > leftBound)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (input.GetKey(KeyCode.RightArrow)  && this.gameObject.transform.postion.x > rightBound)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
