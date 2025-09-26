using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mainMixer;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;


    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";

    void Start()
    {
        // Перевіряємо, чи існує збережене значення гучності
        if (PlayerPrefs.HasKey(MUSIC_VOLUME_KEY))
        {
            // Отримуємо збережене значення
            float savedMusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);

            // 1. Встановлюємо значення бігунка слайдера на збережене
            musicSlider.value = savedMusicVolume;

            // 2. Викликаємо метод для застосування гучності до мікшера
            SetMusicVolume();
        }
        if (PlayerPrefs.HasKey(SFX_VOLUME_KEY))
        {
            // Отримуємо збережене значення
            float savedSFXVolume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY);

            // 1. Встановлюємо значення бігунка слайдера на збережене
            sfxSlider.value = savedSFXVolume;

            // 2. Викликаємо метод для застосування гучності до мікшера
            SetSFXVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        if (volume == 0)
        {
            mainMixer.SetFloat("music", -80f);
        }
        else
        {
            mainMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        }
        // Зберігаємо нове значення
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        if (volume == 0)
        {
            mainMixer.SetFloat("sfx", -80f);
        }
        else
        {
            mainMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        }
        // Зберігаємо нове значення
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }
}