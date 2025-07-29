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
        //animator.play("Idle");
        Vector3 objZ = transform.forward;
        Vector3 targetZ = targetObject.transform.forward;
        if (objZ.z > targetZ.z)
        {
            Debug.Log("Obj: " + objZ.z + " Target: " + targetZ.z);
            //animator.play("Missed");
        }
        animator.Play("New State");
    }
}
