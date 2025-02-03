using UnityEngine;

public class Song : MonoBehaviour
{
    public static Song Instance; // Singleton reference
    public AudioSource audioSource; // Assign your AudioSource here
    public AudioClip musicClip; // Assign the music clip

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes sure the object persists across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy the duplicate instance if it exists
            return;
        }
    }

    private void Start()
    {
        // Play music if an AudioSource and music clip are assigned
        if (audioSource != null && musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true; // Loop the music
            audioSource.Play();
        }
    }
}