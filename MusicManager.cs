using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RestartMusic()
    {
        if (audioSource == null)
            return;

        audioSource.Stop();

        audioSource.time = 0f;

        audioSource.Play();
    }
}