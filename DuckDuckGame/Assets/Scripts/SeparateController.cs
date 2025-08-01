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
        //transform.localScale = new Vector3(4506.337f, 7429.69f, 4559.187f);
        //animator.applyRootMotion = true;
        transform.localScale = new Vector3(5000f, 5000f, 5000f);
    }

    void LateUpdate()
    {
        //transform.localScale = new Vector3(4506.337f, 7429.69f, 4559.187f);
        transform.localScale = new Vector3(5000f, 5000f, 5000f);
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
