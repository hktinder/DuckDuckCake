using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cake_slice"))
        {
            GameManager.Instance.UpdateCakeSliceCount();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("plane") || other.CompareTag("cloud"))
        {
            GameManager.Instance.UpdateLifeCount();
            Destroy(other.gameObject);
        }
    }
}
