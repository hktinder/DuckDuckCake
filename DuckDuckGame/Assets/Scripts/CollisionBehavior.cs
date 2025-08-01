using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    public Animator animator;
    public GameObject targetObject;
    public string targetFunctionName;

    public bool type;
    public float xScale;
    public float yScale;
    public float zScale;

    public Vector3 startingPosition;


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
                    Destroy(this.gameObject, 2f);
                    Debug.Log("Destroy called");
                }
            }
        }
    }

    void Start()
    {
        animator.applyRootMotion = false;
        transform.position = startingPosition;
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
            Destroy(this.gameObject, 1f);
        }
        else if (!type)
        {
            animator.Play("Idle");
        }
    }

    void LateUpdate()
    {
        if (!type)
        {
            Vector3 pos = transform.position;
            pos.x = startingPosition.x;
            pos.z = startingPosition.z;
            transform.position = pos;
        }

        transform.localScale = new Vector3(xScale, yScale, zScale);
    }

}
