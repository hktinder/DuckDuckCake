using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
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
            }
        }
    }
}
