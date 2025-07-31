using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    public Animator animator;
    public GameObject targetObject;
    public string targetFunctionName;

    public bool type;

    private bool collided = false;

    void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            if (other.gameObject == targetObject)
            {
                MonoBehaviour targetScript = targetObject.GetComponent<MonoBehaviour>();
                {
                    Debug.Log("Invoking: " + targetFunctionName);
                    targetScript.SendMessage(targetFunctionName, 1);
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("Collision");
                    //Destroy(this, 2f);
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
        if (animator == null || targetObject == null)
        {
            return;
        }
        Vector3 objZ = transform.position;
        Vector3 targetZ = targetObject.transform.position;
        if (objZ.z < targetZ.z)
        {
            animator.enabled = false;
            animator.enabled = true;
            animator.Play("Missed");
        }
        else if (!type)
        {
            animator.Play("Idle");
        }
    }
}
