using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource musicSource, effectsSource;

    public List<AudioClip> effects;
    public List<AudioClip> music;

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
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    public void PlayLoop(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
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
