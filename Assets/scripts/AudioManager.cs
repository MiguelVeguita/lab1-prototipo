using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip eatSound;
    public AudioClip gameOverSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    // Reproduce la música de fondo
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic == null) return;
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

   
    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }

    public void PlayEatSound() => PlaySound(eatSound);
    public void PlayGameOverSound() => PlaySound(gameOverSound);
}
