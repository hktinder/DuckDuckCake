using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    public AudioClip animationSound;

    private AudioSource source;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.volume = 1f;
    }

    void AnimationSound()
    {
        if (!source.isPlaying)
        {
            source.clip = animationSound;
            source.Play();
            Debug.Log("Playing: " + animationSound.name);
        }
    }
}
