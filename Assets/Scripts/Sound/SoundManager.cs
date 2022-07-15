using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField]
    private AudioSource musicSource, effectsSource;

    public AudioSource MusicSource { get { return musicSource; } set { musicSource = value; } }
    public AudioSource EffectsSource { get { return effectsSource; } set { effectsSource = value; } }

    [Header("Gameplay")]
    public AudioClip HitSound;
    public AudioClip DieSound;
    public AudioClip JumpSound;
    public AudioClip landSound;
    public AudioClip buttonSound;
    [Header("SoundTrack")]
    public AudioClip mainMenuTheme;
    public AudioClip inGameTheme;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        effectsSource.volume = 1;
        musicSource.volume = 1;
    }

    void Start()
    {
        PlayLoop(inGameTheme);
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.clip = clip;
        effectsSource.Play();
    }

    public void PlayLoop(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
