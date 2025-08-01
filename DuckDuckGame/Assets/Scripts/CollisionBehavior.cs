using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    public Animator animator;
    public GameObject targetObject;
    public string targetFunctionName;

    public GameObject thisGameObject;

    public bool type;

    public float xScale;
    public float yScale;
    public float zScale;
    public float xRotation;
    public float yRotation;
    public float zRotation;


    private bool collided = false;

    void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            if (other.gameObject == targetObject)
            {
                MonoBehaviour targetScript = targetObject.GetComponent<MonoBehaviour>();
                {
                    collided = true;
                    Debug.Log("Invoking: " + targetFunctionName);
                    targetScript.SendMessage(targetFunctionName, 1);
                    animator.Play("Collision");
                    Destroy(thisGameObject, 2f);
                    //Debug.Log("Destroy called");
                }
            }
        }
    }

    void Start()
    {
        if (type)
        {
            //animator.Play("Idle");
        }
    }
    void Update()
    {
        if (animator == null || targetObject == null || collided)
        {
            return;
        }
        Vector3 objZ = transform.position;
        Vector3 targetZ = targetObject.transform.position;
        if (objZ.z < targetZ.z)
        {
            animator.Play("Missed");
            Destroy(thisGameObject, 1f);
        }
        else if (!type)
        {
            animator.Play("Idle");
        }
    }

    void LateUpdate()
    {
        transform.localScale = new Vector3(xScale, yScale, zScale);
        //transform.localEulerAngles = new Vector3(xRotation, yRotation, zRotation);
    }

}
