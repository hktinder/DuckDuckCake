using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cake_slice"))
        {
            GameManager.Instance.UpdateCakeSliceCount();
            AudioManager.Instance.PlaySoundEffect("cake");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("plane"))
        {
            GameManager.Instance.UpdateLifeCount();
            AudioManager.Instance.PlaySoundEffect("plane");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("cloud"))
        {
            GameManager.Instance.UpdateLifeCount();
            AudioManager.Instance.PlaySoundEffect("cloud");
            Destroy(other.gameObject);
        }
    }
}
