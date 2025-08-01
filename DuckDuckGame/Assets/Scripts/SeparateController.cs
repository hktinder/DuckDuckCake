using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparateController : MonoBehaviour
{
    public Animator animator;
    public GameObject targetObject;
    public string targetFunctionName;

    private bool collided = false;
    private bool shouldUpdate = true;

    void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            if (other.gameObject == targetObject)
            {
                MonoBehaviour targetScript = targetObject.GetComponent<MonoBehaviour>();
                {
                    shouldUpdate = false;
                    Debug.Log("Invoking: " + targetFunctionName);
                    targetScript.SendMessage(targetFunctionName, 1);
                    animator.applyRootMotion = true;
                    animator.Play("Collision");
                    Destroy(this, 10f);
                }
            }
        }
    }

    void Start()
    {
        transform.localScale = new Vector3(6438f, 14108f, 6916f);
        //animator.applyRootMotion = true;
    }

    void LateUpdate()
    {
        transform.localScale = new Vector3(6438f, 14108f, 6916f);
    }

    void Update()
     {
        if (animator == null || targetObject == null || !shouldUpdate)
        {
            return;
        }
        Vector3 objZ = transform.position;
        Vector3 targetZ = targetObject.transform.position;
        if (objZ.z < targetZ.z)
        {
            animator.applyRootMotion = true;
            animator.Play("Missed");
            Destroy(this, 10f);
        }
    }
}
