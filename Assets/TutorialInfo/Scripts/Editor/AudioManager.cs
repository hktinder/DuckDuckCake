using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource backgroundMusic;
    public AudioSource sfxSource;

    public AudioClip cakeSound;
    public AudioClip planeHitSound;
    public AudioClip cloudHitSound;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
    }

    public void PlaySoundEffect(string effectType)
    {
        if (sfxSource == null) return;

        switch (effectType)
        {
            case "cake":
                if (cakeSound != null)
                    sfxSource.PlayOneShot(cakeSound);
                break;
            case "plane":
                if (planeHitSound != null)
                    sfxSource.PlayOneShot(planeHitSound);
                break;
            case "cloud":
                if (cloudHitSound != null)
                    sfxSource.PlayOneShot(cloudHitSound);
                break;
            case "click":
                if (buttonClickSound != null)
                    sfxSource.PlayOneShot(buttonClickSound);
                break;
        }
    }

    public void ToggleSound()
    {
        AudioListener.volume = (AudioListener.volume == 1f) ? 0f : 1f;
    }
}
