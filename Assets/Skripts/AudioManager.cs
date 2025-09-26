using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

// Визначаємо перелік усіх звуків, які нам потрібні
public enum SFXType
{
    // UI звуки
    ButtonClick,
    Win,
    Lose,

    // Ігрові звуки
    Jump,
    Walk,
    Damage,
    Land,

    // Додавайте інші звуки тут
}

public class AudioManager : MonoBehaviour
{
    // Посилання на AudioSource, який відтворюватиме звукові ефекти
    [SerializeField] AudioSource bgAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] private AudioMixer mainMixer;

    // Словник для зручного доступу до звукових кліпів
    public Dictionary<SFXType, AudioClip> sfxClips = new Dictionary<SFXType, AudioClip>();

    [Header("UI Sounds")]
    [SerializeField] AudioClip buttonClickSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    [Header("Game Sounds")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip landingSound;

    public static AudioManager Instance = null;

    void Awake()
    {
        // Наповнюємо словник, щоб не використовувати if/else або switch
        sfxClips.Add(SFXType.ButtonClick, buttonClickSound);
        sfxClips.Add(SFXType.Win, winSound);
        sfxClips.Add(SFXType.Lose, loseSound);
        sfxClips.Add(SFXType.Jump, jumpSound);
        sfxClips.Add(SFXType.Walk, walkSound);
        sfxClips.Add(SFXType.Damage, damageSound);
        sfxClips.Add(SFXType.Land, landingSound);

        // Цей менеджер також може бути сінглтоном, щоб до нього можна було звертатися звідусіль
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        // Застосовуємо збережені налаштування гучності
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            SetMixerVolume("music", musicVolume);
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
            SetMixerVolume("sfx", sfxVolume);
        }
    }

    // Публічний метод для відтворення звукових ефектів
    public void PlaySFX(SFXType sfxToPlay)
    {
        // Перевіряємо, чи існує звук у нашому словнику
        if (sfxClips.ContainsKey(sfxToPlay))
        {
            // Відтворюємо звук за допомогою PlayOneShot
            sfxAudioSource.PlayOneShot(sfxClips[sfxToPlay]);
        }
        else
        {
            Debug.LogWarning("Звук " + sfxToPlay.ToString() + " не знайдено!");
        }
    }
    private void SetMixerVolume(string parameterName, float volume)
    {
        if (volume == 0)
        {
            mainMixer.SetFloat(parameterName, -80f);
        }
        else
        {
            mainMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        }
    }
}