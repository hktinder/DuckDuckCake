using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehavior : MonoBehaviour
{
    public Animator animator;
    public GameObject targetObject;
    public string targetFunctionName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            MonoBehaviour targetScript = targetObject.GetComponent<MonoBehaviour>();
            {
                Debug.Log("Invoking: " + targetFunctionName);
                targetScript.SendMessage(targetFunctionName, 1);
                //animator.play("Collision");
            }
        }
    }

    void Update()
    {
        if (animator == null || targetObject == null)
        {
            return;
        }
        //animator.play("Idle");
        Vector3 objZ = transform.position;
        Vector3 targetZ = targetObject.transform.position;
        Debug.Log("Obj: " + objZ.z + " Target: " + targetZ.z);
        if (objZ.z < targetZ.z)
        {
            Debug.Log("target object passed me!");
            //animator.play("Missed");
        }
        else
        {
            animator.Play("New State");
        }
    }
}
