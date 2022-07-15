using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    private SoundManager soundManager;

    [Header("Effects Volume")]
    [SerializeField]
    private TextMeshProUGUI eCurrVol;
    [SerializeField]
    private Slider eVolumeSlider;

    [Header("Music Volume")]
    [SerializeField]
    private TextMeshProUGUI mCurrVol;
    [SerializeField]
    private Slider mVolumeSlider;


    void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        soundManager.EffectsSource.volume = eVolumeSlider.value;
        soundManager.MusicSource.volume = mVolumeSlider.value;
        mCurrVol.text = mVolumeSlider.value.ToString();
        eCurrVol.text = eVolumeSlider.value.ToString();
    }

    public void SetEffectsVolume(float volume)
    {
        soundManager.EffectsSource.volume = volume / 100;
        eCurrVol.text = volume.ToString();
    }

    public void SetMusicVolume(float mVolume)
    {
        soundManager.MusicSource.volume = mVolume / 100;
        mCurrVol.text = mVolume.ToString();
    }
}