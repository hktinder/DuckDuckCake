using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    public GameObject targetObject;
    public string targetFunctionName;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.gameObject);
        if (other.gameObject == targetObject)
        {
            MonoBehaviour targetScript = targetObject.GetComponent<MonoBehaviour>();
            if (targetScript != null && targetScript.GetType().GetMethod(targetFunctionName) != null)
            {
                targetScript.Invoke(targetFunctionName, 1);
            }
        }
    }
}
